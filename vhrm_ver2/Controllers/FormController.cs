using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.BusinessLayer;
using vhrm.FrameWork.Entity;

namespace vhrm.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult formQuery([DataSourceRequest]DataSourceRequest request)
        {
            DataTable dtForm = FormAccess.GetForm();
            List<eForm> lstForm = bForm.listFormFromDatatable(dtForm);
            return Json(lstForm.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult updateForm([DataSourceRequest] DataSourceRequest request, eForm _form)
        {
            FormEntity formEntity = new FormEntity();
            formEntity.FormID = _form.FORM_CODE;
            formEntity.FormName = _form.FORM_NAME;
            formEntity.DictionaryID = "";
            formEntity.FilePath = _form.FILE_PATH;
            formEntity.ModuleID = "";
            formEntity.UPDATE_UID = "hieuht";
            bool result = FormAccess.UpdateForm(formEntity);
            return Json(new[] { _form }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult createForm([DataSourceRequest] DataSourceRequest request, eForm _form)
        {
            FormEntity formEntity = new FormEntity();
            formEntity.FormID = _form.FORM_CODE;
            formEntity.FormName = _form.FORM_NAME;
            formEntity.DictionaryID = "";
            formEntity.CREATE_UID = "hieuht";
            formEntity.FilePath = _form.FILE_PATH;
            formEntity.ModuleID = "";
            bool result = FormAccess.InsertForm(formEntity);
            return Json(new[] { _form }.ToDataSourceResult(request, ModelState));
        }
        [HttpPost]
        public ActionResult Excel_export_save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);
            return File(fileContents, contentType, fileName);
        }
    }
}