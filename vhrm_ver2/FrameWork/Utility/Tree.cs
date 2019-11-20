using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vhrm.FrameWork.BusinessLayer;
using vhrm.FrameWork.Entity;
using vhrm.ViewModels;

namespace KSN.FrameWork.Utility
{
    public class Tree
    {
        //public static List<OriganizationUsersViewModel> getTreeGeoDepts()
        //{
        //    var data = bGeoReport.getUsersGeoDeptReports();
        //    List<EmployeeMaster> allUsers = bEmployeeMaster.getAllEmployees();
        //    List<OriganizationUsersViewModel> deptList = new List<OriganizationUsersViewModel>();
        //    OriganizationUsersViewModel currNode = null;
        //    OriganizationUsersViewModel org = data.Where(p => p.DEPTPARENT == null || p.DEPTPARENT == string.Empty).FirstOrDefault();
        //    currNode = org;
        //    OriganizationUsersViewModel geo = Recursive(org, data, allUsers);
        //    if (geo != null)
        //    {
        //        EmployeeMaster user = allUsers.Where(u => u.SYS_EMPID.Trim() == geo.SYS_EMPID.Trim()).FirstOrDefault();
        //        if (user != null)
        //        {
        //            OriganizationUsersViewModel obj = new OriganizationUsersViewModel();
        //            obj.Display = user.EMPNAME;
        //            obj.Key = user.SYS_EMPID;
        //            obj.Flag = 0;
        //            geo.childs.Reverse();
        //            geo.childs.Add(obj);
        //            geo.childs.Reverse();
        //        }
        //        deptList.Add(geo);
        //    }           
        //    return deptList;
        //}
        public static List<OriganizationUsersViewModel> getTreeUserGeoDepts(string depcode)
        {
            var data = bGeoReport.getUsersGeoDeptReports();
            List<EmployeeMaster> allUsers = bEmployeeMaster.getAllEmployees();

            List<OriganizationUsersViewModel> deptList = new List<OriganizationUsersViewModel>();
            OriganizationUsersViewModel org = data.Where(p => p.DEPTCODE == depcode).FirstOrDefault();
            if (org == null) return deptList;
            OriganizationUsersViewModel geo = Recursive(org, data, allUsers);
            OriganizationUsersViewModel current = org;
            List<OriganizationUsersViewModel> result = new List<OriganizationUsersViewModel>();
            List<OriganizationUsersViewModel> usergeoreport = new List<OriganizationUsersViewModel>();

            result.Add(current);
            while (current.childs.Count() > 0)
            {
                current = current.childs[0];
                result.Add(current);
            }
            result.Reverse();
            foreach (OriganizationUsersViewModel usergeo in result)
            {
                List<OriganizationUsersViewModel> georeports = data.Where(g => g.DEPTCODE == usergeo.DEPTCODE).ToList();
                var users = allUsers.Join(georeports, u => u.SYS_EMPID, g => g.SYS_EMPID, ((u, g) => new { User = u, Geo = g }));
                usergeo.childs.Clear();
                usergeo.Display = usergeo.DEPTNAME;
                usergeo.Key = usergeo.DEPTCODE;
                foreach (var user in users)
                {
                    OriganizationUsersViewModel obj = new OriganizationUsersViewModel();
                    obj.DEPTCODE = usergeo.DEPTCODE;
                    obj.Display = user.User.EMPNAME;
                    obj.Key = user.Geo.SYS_EMPID;
                    obj.Flag = 1;
                    obj.EMPID = user.User.EMPID;
                    if (usergeo.childs.Where(e=>e.Key == obj.Key).FirstOrDefault() == null)
                        usergeo.childs.Add(obj);
                }                           
            }           
            for (int i = 0; i < result.Count - 1; i++)
            {
                result[i].childs.Add(result[i + 1]);
            }
            usergeoreport.Add(result[0]);
            return usergeoreport;
        }

        public static List<FunctionUsersViewModel> getTreeUserFunctions(string funccode)
        {
            var data = bFunctionReport.getUsersFunctionReports();
            List<EmployeeMaster> allUsers = bEmployeeMaster.getAllEmployees();

            List<FunctionUsersViewModel> funcList = new List<FunctionUsersViewModel>();
            FunctionUsersViewModel func = data.Where(p => p.FUNCCODE == funccode).FirstOrDefault();
            if (func == null) return funcList;
            FunctionUsersViewModel geo = Recursive(func, data, allUsers);
            FunctionUsersViewModel current = func;
            List<FunctionUsersViewModel> result = new List<FunctionUsersViewModel>();
            List<FunctionUsersViewModel> userfuncreport = new List<FunctionUsersViewModel>();

            result.Add(current);
            while (current.childs.Count() > 0)
            {
                current = current.childs[0];
                result.Add(current);
            }
            result.Reverse();
            foreach (FunctionUsersViewModel userfunc in result)
            {
                List<FunctionUsersViewModel> georeports = data.Where(g => g.FUNCCODE == userfunc.FUNCCODE).ToList();
                var users = allUsers.Join(georeports, u => u.SYS_EMPID, g => g.SYS_EMPID, ((u, g) => new { User = u, Geo = g }));
                userfunc.childs.Clear();
                userfunc.Display = userfunc.FUNCNAME;
                userfunc.Key = userfunc.FUNCCODE;
                foreach (var user in users)
                {
                    FunctionUsersViewModel obj = new FunctionUsersViewModel();
                    obj.FUNCCODE = userfunc.FUNCCODE;
                    obj.Display = user.User.EMPNAME;
                    obj.Key = user.Geo.SYS_EMPID;
                    obj.Flag = 1;
                    obj.EMPID = user.User.EMPID;
                    if (userfunc.childs.Where(e => e.Key == obj.Key).FirstOrDefault() == null)
                        userfunc.childs.Add(obj);
                }
            }
            for (int i = 0; i < result.Count - 1; i++)
            {
                result[i].childs.Add(result[i + 1]);
            }
            userfuncreport.Add(result[0]);
            return userfuncreport;
        }

       
        public static List<OriganizationUsersViewModel> getUserGeoDeptsFormTree(string depcode)
        {
            var data = bGeoReport.getUsersGeoDeptReports();
            List<EmployeeMaster> allUsers = bEmployeeMaster.getAllEmployees();

            List<OriganizationUsersViewModel> deptList = new List<OriganizationUsersViewModel>();
            OriganizationUsersViewModel org = data.Where(p => p.DEPTCODE == depcode).FirstOrDefault();
            if (org == null) return deptList;
            OriganizationUsersViewModel geo = Recursive(org, data, allUsers);
            OriganizationUsersViewModel current = org;
            List<OriganizationUsersViewModel> result = new List<OriganizationUsersViewModel>();
            List<OriganizationUsersViewModel> dataTree = new List<OriganizationUsersViewModel>();
            List<OriganizationUsersViewModel> usergeoreport = new List<OriganizationUsersViewModel>();
            current.leaf = false;
            result.Add(current);
            dataTree.Add(current);
            while (current.childs.Count() > 0)
            {
                current = current.childs[0];
                current.leaf = false;
                result.Add(current);
                dataTree.Add(current);
            }
            foreach (OriganizationUsersViewModel usergeo in result)
            {
                List<OriganizationUsersViewModel> georeports = data.Where(g => g.DEPTCODE == usergeo.DEPTCODE).ToList();
                var users = allUsers.Join(georeports, u => u.SYS_EMPID, g => g.SYS_EMPID, ((u, g) => new { User = u, Geo = g }));
                usergeo.Display = usergeo.DEPTNAME;
                usergeo.Key = usergeo.DEPTCODE;
                usergeo.DEPTPARENT = usergeo.DEPTPARENT;
                foreach (var user in users)
                {
                    OriganizationUsersViewModel obj = new OriganizationUsersViewModel();
                    obj.Display = user.User.EMPNAME;
                    obj.Key = user.Geo.SYS_EMPID;
                    obj.Flag = 1;
                    obj.DEPTPARENT = usergeo.DEPTCODE;
                    obj.leaf = true;
                    obj.EMPID = user.User.EMPID;
                    if (dataTree.Where(e => e.Key == obj.Key).FirstOrDefault() == null)
                        dataTree.Add(obj);
                }
            }
            return dataTree;
        }
        public static OriganizationUsersViewModel Recursive(OriganizationUsersViewModel geo, List<OriganizationUsersViewModel> deptList, List<EmployeeMaster> allUsers)
        {

            if (deptList.Where(c => c.DEPTCODE == geo.DEPTPARENT).Count() < 1)
            {                
                //if (string.IsNullOrEmpty(geo.GEOREPORTCD))
                //    return null;
                //else
                {
                    //EmployeeMaster user = allUsers.Where(u => u.SYS_EMPID.Trim() == geo.SYS_EMPID.Trim()).FirstOrDefault();
                    //if (user != null)
                    //{
                    //    OriganizationUsersViewModel obj = new OriganizationUsersViewModel();
                    //    obj.Display = user.EMPNAME;
                    //    obj.Key = user.SYS_EMPID;
                    //    obj.Flag = 0;
                    //    geo.childs.Add(obj);
                    //}
                    return geo;
                }                
            }
            else
            {
                List<OriganizationUsersViewModel> newList = new List<OriganizationUsersViewModel>();
                foreach (OriganizationUsersViewModel ca in deptList.Where(c => c.DEPTCODE == geo.DEPTPARENT))
                {
                    OriganizationUsersViewModel org = Recursive(ca, deptList, allUsers);
                    if (org != null)
                    {
                        //EmployeeMaster user = allUsers.Where(u => u.SYS_EMPID.Trim() == org.SYS_EMPID.Trim()).FirstOrDefault();                        
                        
                        //OriganizationUsersViewModel eObj = newList.Where(p => p.DEPTCODE == org.DEPTCODE).FirstOrDefault();
                        //if (eObj != null)
                        {
                            //if (user != null)
                            //{
                            //    OriganizationUsersViewModel obj = new OriganizationUsersViewModel();
                            //    obj.Display = user.EMPNAME;
                            //    obj.Key = user.SYS_EMPID;
                            //    obj.Flag = 0;
                            //    eObj.childs.Add(obj);
                            //}
                        }
                        //else if (eObj == null)
                        {
                            newList.Add(org);
                        }
                            
                    }
                }
                geo.childs = newList;
                return geo;
            }
        }
        public static FunctionUsersViewModel Recursive(FunctionUsersViewModel func, List<FunctionUsersViewModel> funcList, List<EmployeeMaster> allUsers)
        {

            if (funcList.Where(c => c.FUNCCODE == func.FUNCPARENT).Count() < 1)
            {
                //if (string.IsNullOrEmpty(geo.GEOREPORTCD))
                //    return null;
                //else
                {
                    //EmployeeMaster user = allUsers.Where(u => u.SYS_EMPID.Trim() == geo.SYS_EMPID.Trim()).FirstOrDefault();
                    //if (user != null)
                    //{
                    //    OriganizationUsersViewModel obj = new OriganizationUsersViewModel();
                    //    obj.Display = user.EMPNAME;
                    //    obj.Key = user.SYS_EMPID;
                    //    obj.Flag = 0;
                    //    geo.childs.Add(obj);
                    //}
                    return func;
                }
            }
            else
            {
                List<FunctionUsersViewModel> newList = new List<FunctionUsersViewModel>();
                foreach (FunctionUsersViewModel ca in funcList.Where(c => c.FUNCCODE == func.FUNCPARENT))
                {
                    FunctionUsersViewModel funct = Recursive(ca, funcList, allUsers);
                    if (funct != null)
                    {
                        //EmployeeMaster user = allUsers.Where(u => u.SYS_EMPID.Trim() == org.SYS_EMPID.Trim()).FirstOrDefault();                        

                        //OriganizationUsersViewModel eObj = newList.Where(p => p.DEPTCODE == org.DEPTCODE).FirstOrDefault();
                        //if (eObj != null)
                        {
                            //if (user != null)
                            //{
                            //    OriganizationUsersViewModel obj = new OriganizationUsersViewModel();
                            //    obj.Display = user.EMPNAME;
                            //    obj.Key = user.SYS_EMPID;
                            //    obj.Flag = 0;
                            //    eObj.childs.Add(obj);
                            //}
                        }
                        //else if (eObj == null)
                        {
                            newList.Add(funct);
                        }

                    }
                }
                func.childs = newList;
                return func;
            }
        }
    }
}