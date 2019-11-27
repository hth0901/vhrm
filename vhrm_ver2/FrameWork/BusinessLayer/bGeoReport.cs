using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.Entity;
using vhrm.ViewModels;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bGeoReport
    {
        public static List<GeoReport> getAllGeoReports()
        {
            List<GeoReport> geoReports = new List<GeoReport>();
            GeoReportAccess access = new GeoReportAccess();
            DataTable dtResult = access.GetGeoReports();
            foreach (DataRow dtr in dtResult.Rows)
            {
                GeoReport item = new GeoReport
                {
                    GEOREPORTCD = dtr["GEOREPORTCD"].ToString(),
                    DEPTCODE = dtr["DEPTCODE"].ToString(),
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    APPLYDATE = DateTime.Parse(string.IsNullOrEmpty(dtr["APPLYDATE"].ToString()) ? "1-1-1999" : dtr["APPLYDATE"].ToString()),
                    ISACTIVE = dtr["ISACTIVE"].ToString(),
                    POSITION = dtr["POSITION"].ToString(),
                    SKILL = dtr["SKILL"].ToString(),
                    REMARK = dtr["REMARK"].ToString(),
                    GEOREPORTLEVEL = dtr["GEOREPORTLEVEL"].ToString(),
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    CREATE_DT = dtr["CREATE_DT"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                    UPDATE_DT = dtr["UPDATE_DT"].ToString(),
                };
                geoReports.Add(item);
            }
            return geoReports;
        }

        public static List<eGeoReportItem> getGeoReportByDepartment(string deptcode)
        {
            List<eGeoReportItem> lstResult = new List<eGeoReportItem>();
            DataTable dtResult = GeoReportAccess.getReportByDepartment(deptcode);
            /*
            foreach (DataRow dtr in dtResult.Rows)
            {
                eGeoReportItem item = new eGeoReportItem();
                item.GEOREPORTCD = dtr["GEOREPORTCD"].ToString();
                item.DEPTCODE = dtr["DEPTCODE"].ToString();
                item.SYS_EMPID = dtr["SYS_EMPID"].ToString();
                string strDate = dtr["APPLYDATE"].ToString();
                item.APPLYDATE = DateTime.ParseExact(strDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                item.ISACTIVE = dtr["ISACTIVE"].ToString();
                item.EMPNAME = dtr["EMPNAME"].ToString();
                lstResult.Add(item);
            }
            */

            foreach (DataRow dtr in dtResult.Rows)
            {
                eGeoReportItem item = new eGeoReportItem();
                item.GEOREPORTCD = dtr["GEOREPORTCD"].ToString();
                item.DEPTCODE = dtr["DEPTCODE"].ToString();
                item.SYS_EMPID = dtr["SYS_EMPID"].ToString();
                string strDate = dtr["APPLYDATE"].ToString();
                item.APPLYDATE = DateTime.ParseExact(strDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                int nActive = 0;
                int.TryParse(dtr["ISACTIVE"].ToString(), out nActive);
                item.ISACTIVE = Convert.ToBoolean(nActive);
                item.EMPNAME = dtr["EMPNAME"].ToString();
                lstResult.Add(item);
            }

            return lstResult;
        }
        //Version 2.0 for improving performance.
        public static List<GeoDeptViewModel> getGeoDeptReportsRegistered()
        {
            List<GeoDeptViewModel> geoReports = new List<GeoDeptViewModel>();
            GeoReportAccess access = new GeoReportAccess();
            DataTable dtResult = access.GetTreeGeoReportsRegistered();
            foreach (DataRow dtr in dtResult.Rows)
            {
                GeoDeptViewModel item = new GeoDeptViewModel
                {
                    GEOREPORTCD = dtr["GEOREPORTCD"].ToString(),
                    DEPTNAME = dtr["DEPTNAME"].ToString(),
                    DEPTCODE = dtr["DEPTCODE"].ToString(),
                    DEPTPARENT = dtr["DEPTPARENT"].ToString()
                };
                geoReports.Add(item);
            }
            return geoReports;
        }
        public static List<GeoDeptViewModel> getGeoDeptReports()
        {
            List<GeoDeptViewModel> geoReports = new List<GeoDeptViewModel>();
            GeoReportAccess access = new GeoReportAccess();
            DataTable dtResult = access.GetTreeGeoReports();
            foreach (DataRow dtr in dtResult.Rows)
            {
                GeoDeptViewModel item = new GeoDeptViewModel
                {
                    GEOREPORTCD = dtr["REPORTCD"].ToString(),
                    DEPTNAME = dtr["DEPTNAME"].ToString(),
                    DEPTCODE = dtr["DEPTCODE"].ToString(),
                    DEPTPARENT = dtr["DEPTPARENT"].ToString()
                };
                geoReports.Add(item);
            }
            return geoReports;
        }

        public static List<OriganizationUsersViewModel> getUsersGeoDeptReports()
        {
            List<OriganizationUsersViewModel> geoReports = new List<OriganizationUsersViewModel>();
            GeoReportAccess access = new GeoReportAccess();
            DataTable dtResult = access.GetTreeGeoReports();
            foreach (DataRow dtr in dtResult.Rows)
            {
                OriganizationUsersViewModel item = new OriganizationUsersViewModel
                {
                    Display = dtr["DEPTNAME"].ToString(),
                    Key = dtr["REPORTCD"].ToString(),
                    Flag = 0,
                    GEOREPORTCD = dtr["REPORTCD"].ToString(),
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    DEPTNAME = dtr["DEPTNAME"].ToString(),
                    DEPTCODE = dtr["DEPTCODE"].ToString(),
                    DEPTPARENT = dtr["DEPTPARENT"].ToString()
                };
                geoReports.Add(item);
            }
            return geoReports;
        }
        //Version 2.0 for improving performance.
        public static List<GeoDeptViewModel> getTreeGeoDepts()
        {
            var geoReports = getGeoDeptReportsRegistered();//Lay all GeoReport.
            if(geoReports == null || geoReports.Count == 0)
                return new List<GeoDeptViewModel>(); 
            var data = getGeoDeptReports();

            List<GeoDeptViewModel> result = new List<GeoDeptViewModel>();
            GeoDeptViewModel root = new GeoDeptViewModel();
            foreach (GeoDeptViewModel geo in geoReports)
            {
                GeoDeptViewModel geoTemp = geo;
                geo.isChild = false;
                while (geoTemp != null && geoTemp.DEPTPARENT != null && !string.IsNullOrEmpty(geoTemp.DEPTPARENT))
                {
                    if (result.Where(r => r.DEPTCODE == geoTemp.DEPTCODE).FirstOrDefault() == null)
                    {
                        result.Add(geoTemp);
                    }
                    geoTemp = data.Where(g => g.DEPTCODE == geoTemp.DEPTPARENT).FirstOrDefault();
                    if (geoTemp != null)
                    {
                        geoTemp.isChild = true;
                        root = geoTemp;
                    }
                }
            }
            if (result.Where(r => r.DEPTCODE == root.DEPTCODE).FirstOrDefault() == null)
            {
                result.Add(root);
            }
            List<GeoDeptViewModel> finalResult = new List<GeoDeptViewModel>();
            GeoDeptViewModel geoRoot = GeoRecursive(root, result);
            if (geoRoot != null)
            {
                finalResult.Add(geoRoot);
            }
            return finalResult;
        }
        public static GeoDeptViewModel GeoRecursive(GeoDeptViewModel org, List<GeoDeptViewModel> list)
        {
            var objects = list.Where(c => c.DEPTPARENT == org.DEPTCODE);

            if (objects.Count() < 1)
            {
                return org;
            }
            else
            {
                List<GeoDeptViewModel> newList = new List<GeoDeptViewModel>();
                foreach (GeoDeptViewModel ca in objects)
                {
                    GeoDeptViewModel child = GeoRecursive(ca, list);
                    if (child != null)
                    {
                        if (newList.Where(p => p.DEPTCODE == child.DEPTCODE).FirstOrDefault() == null)
                        {
                            newList.Add(child);
                        }

                    }
                }
                org.GeoDeptViewModels = newList;
                return org;
            }
        }
        //Version: 1.0
        //public static List<GeoDeptViewModel> getTreeGeoDepts()
        //{
        //    var data = getGeoDeptReports();
        //    int count = 0;
        //    List<GeoDeptViewModel> a = new List<GeoDeptViewModel>();
        //    a = (from e in data
        //         select new GeoDeptViewModel
        //         {
        //             DEPTCODE = e.DEPTCODE,
        //             DEPTNAME = e.DEPTNAME,
        //             DEPTPARENT = e.DEPTPARENT,
        //             SYS_EMPID = e.SYS_EMPID,
        //             isChild = data.Where(obj => obj.DEPTPARENT == e.DEPTCODE).FirstOrDefault() != null,
        //             GEOREPORTCD = e.GEOREPORTCD
        //         }).ToList();
        //    a.RemoveAll(obj => obj.isChild == false && string.IsNullOrEmpty(obj.GEOREPORTCD));

        //    while (count < 4)
        //    {
        //       a = (from e in a
        //                                    select new GeoDeptViewModel
        //                                    {
        //                                        DEPTCODE = e.DEPTCODE,
        //                                        DEPTNAME = e.DEPTNAME,
        //                                        DEPTPARENT = e.DEPTPARENT,
        //                                        SYS_EMPID = e.SYS_EMPID,
        //                                        isChild = a.Where(obj => obj.DEPTPARENT == e.DEPTCODE).FirstOrDefault() != null,
        //                                        GEOREPORTCD = e.GEOREPORTCD
        //                                    }).ToList();
        //        a.RemoveAll(obj => obj.isChild == false && string.IsNullOrEmpty(obj.GEOREPORTCD));
        //        count++;
        //    }            
        //    var result = a.Distinct(new GeoComparer<GeoDeptViewModel>());
        //    return result.ToList();
        //}
        public static List<GeoDeptViewModel> getTreeGeoDepts(string deptCode)
        {
            var data = getGeoDeptReports();
            List<GeoDeptViewModel> deptList = new List<GeoDeptViewModel>();
            List<GeoDeptViewModel> result = new List<GeoDeptViewModel>();
            GeoDeptViewModel org = data.Where(p => p.DEPTPARENT == null || p.DEPTPARENT == string.Empty).FirstOrDefault();
            GeoDeptViewModel geo = Recursive(org, data, ref result);
            if (geo != null)
            {
                deptList.Add(geo);
                result.Add(geo);
            }
            return result;
        }
        public static List<EmployeeMaster> getUserInGeoReportByDeptCode(string deptCode)
        {
            List<EmployeeMaster> userList = new List<EmployeeMaster>();
            GeoReportAccess access = new GeoReportAccess();
            DataTable dtResult = access.GetUserGeoReports(deptCode);
            foreach (DataRow dtr in dtResult.Rows)
            {
                EmployeeMaster item = new EmployeeMaster
                {
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    EMPNAME = dtr["EMPNAME"].ToString(), //+ "," + dtr["SYS_EMPID"].ToString(),
                    DEPTCODE = dtr["DEPTCODE"].ToString(),
                    EMPID = dtr["EMPID"].ToString()
                };
                userList.Add(item);
            }
            return userList;
        }
        public static GeoDeptViewModel Recursive(GeoDeptViewModel dept, List<GeoDeptViewModel> deptList, ref List<GeoDeptViewModel> result)
        {
            var objects = deptList.Where(c => c.DEPTPARENT == dept.DEPTCODE);

            if (objects.Count() < 1)
            {
                if (string.IsNullOrEmpty(dept.GEOREPORTCD))
                    return null;
                return dept;
            }
            else
            {
                List<GeoDeptViewModel> newList = new List<GeoDeptViewModel>();
                foreach (GeoDeptViewModel ca in objects)
                {
                    GeoDeptViewModel org = Recursive(ca, deptList, ref result);
                    if (org != null)
                    {
                        if (newList.Where(p => p.DEPTCODE == org.DEPTCODE).FirstOrDefault() == null)
                        {
                            //newList.Add(org);
                            result.Add(org);
                        }

                    }
                }
                dept.GeoDeptViewModels = newList;
                return dept;
            }
        }
    }
    class GeoComparer<T> : IEqualityComparer<T> where T : GeoDeptViewModel
    {
        public bool Equals(T x, T y)
        {
            return x.DEPTNAME.Equals(y.DEPTNAME);
        }

        public int GetHashCode(T obj)
        {
            return obj.DEPTCODE.GetHashCode();
        }
    }
}