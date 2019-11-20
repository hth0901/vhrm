using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace vhrm.FrameWork.Entity
{
    public class ContractList
    {
        private List<LaborContractEntity> contractList;

        public List<LaborContractEntity> GetContractList()
        {
            return contractList;
        }

        public ContractList()
        {
            contractList = new List<LaborContractEntity>();
        }

        public ContractList(DataTable dt)
        {
            contractList = new List<LaborContractEntity>();
            foreach (DataRow dr in dt.Rows)
            {
                LaborContractEntity ct = new LaborContractEntity(dr);
                contractList.Add(ct);
            }
        }

        public void Adjust()
        {
            //if list consist only 1 or 0 contract: do nothing
            if (contractList.Count < 2)
                return;

            //reset
            foreach (LaborContractEntity ct in contractList)
            {
                if (!ct.ContractKind.Equals(LaborContractEntity.SEASON) && !ct.ContractKind.Equals(LaborContractEntity.TEMPERARY))
                    ct.Appendix = LaborContractEntity.LABOURCONTRACT_APPENDIX;
            }

           // 1. find first contract
            LaborContractEntity firstCt = null, DFCT = null, RFCT = null, IDCT=null;
            firstCt = FindFirstContract();

            //2. find first official contract
            //If first contract is Official definite then set direct DFCT = firstCt
            if (firstCt.ContractKind.Equals(LaborContractEntity.OFFICIAL_DEFINITE))
            {
                DFCT = firstCt;
                firstCt = null;
            }
            else if (firstCt != null)
            {
                firstCt.Appendix = LaborContractEntity.LABOURCONTRACT_CONTRACT;
                DFCT = FindFirstOfficialContract(firstCt);
            }

            //3. find second official contract
            if (DFCT != null)
            {
                DFCT.ContractKind = LaborContractEntity.OFFICIAL_DEFINITE;
                DFCT.Appendix = LaborContractEntity.LABOURCONTRACT_CONTRACT;
                RFCT = FindSecondOfficialContract(DFCT);
                
            }

            //4. find indefinitive contract

            if (RFCT != null)
            {
                RFCT.ContractKind = LaborContractEntity.OFFICIAL_REDEFINITE;
                RFCT.Appendix = LaborContractEntity.LABOURCONTRACT_CONTRACT;
                IDCT = FindIndifiniteOfficialContract(RFCT);
                
            }

            if (IDCT != null)
            {
                IDCT.ContractKind = LaborContractEntity.OFFICIAL_INDEFINITE;
                IDCT.Appendix = LaborContractEntity.LABOURCONTRACT_CONTRACT;
            }


            //Update contract
            foreach (LaborContractEntity ct in contractList)
            {
                if (firstCt != null && ct.ContractNo.Equals(firstCt.ContractNo))
                {
                    ct.Appendix = firstCt.Appendix;
                }
                else if (DFCT != null && ct.ContractNo.Equals(DFCT.ContractNo))
                {
                    ct.Appendix = DFCT.Appendix;
                    ct.ContractKind = DFCT.ContractKind;
                }
                else if (RFCT != null && ct.ContractNo.Equals(RFCT.ContractNo))
                {
                    ct.Appendix = RFCT.Appendix;
                    ct.ContractKind = RFCT.ContractKind;
                }
                else if (IDCT != null && ct.ContractNo.Equals(IDCT.ContractNo))
                {
                    ct.Appendix = IDCT.Appendix;
                    ct.ContractKind = IDCT.ContractKind;
                }

                //update appendix
                if (DFCT != null && ct.RealValidityFrom > DFCT.RealValidityFrom && (RFCT == null || ct.RealValidityFrom < RFCT.RealValidityFrom))
                {
                    ct.ContractKind = DFCT.ContractKind;
                }

                if (RFCT != null && ct.RealValidityFrom > RFCT.RealValidityFrom && (IDCT == null || ct.RealValidityFrom < IDCT.RealValidityFrom))
                {
                    ct.ContractKind = RFCT.ContractKind;
                }

                if (IDCT != null && ct.RealValidityFrom > IDCT.RealValidityFrom)
                {
                    ct.ContractKind = IDCT.ContractKind;
                }
                
                
            }


        }

        private LaborContractEntity FindIndifiniteOfficialContract(LaborContractEntity RFCT)
        {
            LaborContractEntity IDCT = null;
            foreach (LaborContractEntity ct in contractList)
            {
                if (RFCT.RealValidityFrom.AddYears(1).Equals(ct.RealValidityFrom))
                    IDCT = ct;
            }
            return IDCT;
        }

        private LaborContractEntity FindSecondOfficialContract(LaborContractEntity DFCT)
        {
            LaborContractEntity secondOfficialCt = null;
            foreach (LaborContractEntity ct in contractList)
            {
                if (DFCT.RealValidityFrom.AddYears(1).Equals(ct.RealValidityFrom))
                    secondOfficialCt = ct;
            }

            return secondOfficialCt;
        }

        private LaborContractEntity FindFirstOfficialContract(LaborContractEntity fistCt)
        {
            LaborContractEntity firstOfficialCt = null;
            foreach (LaborContractEntity ct in contractList)
            {
                if (ct.RealValidityFrom.Equals(fistCt.RealValidityFrom.AddMonths(1)))
                    firstOfficialCt = ct;
                if (firstOfficialCt == null && ct.RealValidityFrom.Equals(fistCt.RealValidityFrom.AddMonths(2)))
                    firstOfficialCt = ct;
            }

            return firstOfficialCt;
        }

        private LaborContractEntity FindFirstContract()
        {
            LaborContractEntity firstCt = contractList.FirstOrDefault();
            foreach (LaborContractEntity ct in contractList)
            {
                if (firstCt.RealValidityFrom > ct.RealValidityFrom && !ct.ContractKind.Equals(LaborContractEntity.SEASON) && !ct.ContractKind.Equals(LaborContractEntity.TEMPERARY))
                    firstCt = ct;
            }

            return firstCt;
        }

        public void GenerateNewContractNo()
        {
            int contractCount = 0;
            int appendixCount = 0;
            string contractNo = "";
            for (int i = contractList.Count - 1 ; i >= 0; i--)
            {
                if (contractList[i].Appendix.Equals("0"))
                {
                    if (contractList[i].ContractKind.Contains("P") || contractList[i].ContractKind.Contains("A") || contractList[i].ContractKind.Contains("DF"))
                        contractCount = 0;
                    else  if (contractList[i].ContractKind.Contains("ID"))
                        contractCount = 2;
                    else if(contractList[i].ContractKind.Contains("RF"))
                        contractCount = 1;
                    contractCount++;
                    appendixCount = 1;
                }
                else
                {
                    appendixCount++;
                }

                string oldContractNo = contractList[i].ContractNo;
                contractNo = oldContractNo.Substring(0, oldContractNo.IndexOf('_') + 1).Replace(".","");
                contractNo += getTextNumber(contractCount);
                contractNo += ".";
                contractNo += appendixCount.ToString();
                contractNo += "_";
                contractNo += contractList[i].Empid;

                

                contractList[i].FixedContractNo = contractNo;

            }
        }

        private string getTextNumber(int num)
        {
            if (num < 10)
                return "0" + num.ToString();
            else
                return num.ToString();
        }
    }
}