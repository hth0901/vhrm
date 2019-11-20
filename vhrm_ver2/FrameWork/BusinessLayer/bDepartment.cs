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
    public static class bDepartment
    {
        private static List<TreeViewItemViewModel> projectData;

        public static List<eDepartmentItem> getDeptTree()
        {
            List<eDepartmentItem> lstResult = new List<eDepartmentItem>();
            DataTable dtResult = new DataTable();
            dtResult = aDepartmentItemAccess.getDeptTreeFull();
            foreach(DataRow dtr in dtResult.Rows)
            {
                eDepartmentItem item = new eDepartmentItem();
                item.DEPTCODE = dtr["DEPTCODE"].ToString();
                item.DEPTNAME = dtr["DEPTNAME"].ToString();
                item.DEPTPARENT = dtr["DEPTPARENT"].ToString();
                item.ISLEAF = dtr["ISLEAF"].ToString();
                lstResult.Add(item);
            }
            return lstResult;
        }

        public static List<eDepartmentItem> getDeptTreeVer2()
        {
            List<eDepartmentItem> lstResult = new List<eDepartmentItem>();
            DataTable dtResult = new DataTable();
            dtResult = aDeptAccessVer2.getAllDept();
            foreach(DataRow dtr in dtResult.Rows)
            {
                eDepartmentItem item = new eDepartmentItem();
                item.DEPTCODE = dtr["DEPTCODE"].ToString();
                item.DEPTNAME = dtr["DEPTNAME"].ToString();
                item.DEPTPARENT = dtr["DEPTPARENT"].ToString();
                item.ISLEAF = dtr["ISLEAF"].ToString();
                lstResult.Add(item);
            }
            return lstResult;
        }
        static bDepartment()
        {
            projectData = new List<TreeViewItemViewModel>();
            projectData.Add(new TreeViewItemViewModel
            {
                dkm = "1",
                text = "My Documents",
                expanded = true,
                hasChildren = true,
                spriteCssClass = "rootfolder",
                items = new List<TreeViewItemViewModel>
                       {
                           new TreeViewItemViewModel
                           {
                                dkm = "2",
                                text = "Kendo UI Project",
                                expanded  = true,
                                spriteCssClass = "folder",
                                hasChildren = true,
                                items = new List<TreeViewItemViewModel>
                                {
                                    new TreeViewItemViewModel
                                    {
                                            dkm = "3",
                                            text ="about.html",
                                            spriteCssClass = "html"
                                    },
                                    new TreeViewItemViewModel
                                    {
                                            dkm = "4",
                                            text ="index.html",
                                            spriteCssClass = "html"
                                    },
                                    new TreeViewItemViewModel
                                    {
                                            dkm = "5",
                                            text ="logo.png",
                                            spriteCssClass = "image"
                                    }
                                }
                           },
                           new TreeViewItemViewModel
                           {
                                dkm = "6",
                                text = "New Web Site",
                                expanded  = true,
                                spriteCssClass = "folder",
                                hasChildren = true,
                                items = new List<TreeViewItemViewModel>
                                {
                                    new TreeViewItemViewModel
                                    {
                                            dkm = "7",
                                            text ="mockup.jpg",
                                            spriteCssClass = "image"
                                    },
                                    new TreeViewItemViewModel
                                    {
                                            dkm = "8",
                                            text ="Research.pdf",
                                            spriteCssClass = "pdf"
                                    }
                                }
                           },
                           new TreeViewItemViewModel
                           {
                                dkm = "9",
                                text = "Reports",
                                expanded  = true,
                                spriteCssClass = "folder",
                                hasChildren = true,
                                items = new List<TreeViewItemViewModel>
                                {
                                    new TreeViewItemViewModel
                                    {
                                            dkm = "10",
                                            text ="February.pdf",
                                            spriteCssClass = "pdf"
                                    },
                                    new TreeViewItemViewModel
                                    {
                                            dkm = "11",
                                            text ="March.pdf",
                                            spriteCssClass = "pdf"
                                    },
                                        new TreeViewItemViewModel
                                    {
                                            dkm = "12",
                                            text ="April.pdf",
                                            spriteCssClass = "pdf"
                                    }
                                }
                           }
                       }
            });
        }

        public static List<TreeViewItemViewModel> GetProjectData()
        {
            return projectData;
        }

        public static IEnumerable<TreeViewItemViewModel> GetChildren(string dkm)
        {
            Queue<TreeViewItemViewModel> items = new Queue<TreeViewItemViewModel>(projectData);

            while (items.Count > 0)
            {
                var current = items.Dequeue();
                if (current.dkm == dkm)
                {
                    return current.items.Select(o => new TreeViewItemViewModel
                    {
                        dkm = o.dkm,
                        text = o.text,
                        expanded = o.expanded,
                        hasChildren = o.hasChildren,
                        imageUrl = o.imageUrl,
                        spriteCssClass = o.spriteCssClass
                    });
                }

                if (current.hasChildren)
                {
                    foreach (var item in current.items)
                    {
                        items.Enqueue(item);
                    }
                }
            }

            return new List<TreeViewItemViewModel>();
        }
    }
}