using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vhrm.FrameWork.Entity;

namespace vhrm.Controllers
{
    [RoutePrefix("api/orgconfig")]
    public class OrgController : ApiController
    {
        // GET api/<controller>
        [Route("test")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "org1", "org2" };
        }

        [Route("addnewdept")]
        [HttpPost]
        [AllowAnonymous]
        public eDepartmentItem addNewDept(eDepartmentItem _dept)
        {
            eDepartmentItem result = new eDepartmentItem();
            result.DEPTNAME = _dept.DEPTNAME;
            result.DEPTSHORTNAME = _dept.DEPTSHORTNAME;
            result.ISACTIVE = _dept.ISACTIVE;
            result.DEPTPARENT = _dept.DEPTPARENT;
            return result;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}