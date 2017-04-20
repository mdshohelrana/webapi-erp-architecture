using System;
using System.Net.Http;
using EMS.Services.Interfaces;
using System.Web.Http;
using EMS.Application.Hrm.Interfaces;
using System.Net;
using EMS.Infra.CrossCutting.Log.ErrorHelper;
using EMS.Domain.Hrm.Dto;
using EMS.Services.Controllers.Common;

namespace EMS.Services.Controllers.Hrm
{
    //[AuthorizationRequired]
    //[RoutePrefix("v1/Employee/Product")]
    public class EmployeeController : BaseApiController, IEmployeeApiController
    {
        private readonly IEmployeeAppService _employeeAppService;

        #region Constructor

        public EmployeeController(IEmployeeAppService employeeAppService)
        {
            if (employeeAppService == null)
                throw new ArgumentNullException("employeeAppService");

            _employeeAppService = employeeAppService;
        }

        #endregion

        [HttpGet]
        public HttpResponseMessage GetEmployeeById(long id)
        {
            if (id != 0)
            {
                var employee = _employeeAppService.GetById(id);
                if (employee != null)
                    return Request.CreateResponse(HttpStatusCode.OK, employee);

                throw new ApiDataException(1001, "No product found for this id.", HttpStatusCode.NotFound);
            }
            throw new ApiException() { ErrorCode = (int)HttpStatusCode.BadRequest, ErrorDescription = "Bad Request..." };
        }

        [HttpDelete]
        public HttpResponseMessage Delete(long id)
        {
            throw new NotImplementedException();
            //if (id > 0)
            //{
            //    var isSuccess = _employeeAppService.Remove(id);
            //    if (isSuccess)
            //    {
            //        return Request.CreateResponse(HttpStatusCode.OK, isSuccess);
            //    }
            //    throw new ApiDataException(1002, "Product is already deleted or not exist in system.", HttpStatusCode.NoContent);
            //}
            //throw new ApiException() { ErrorCode = (int)HttpStatusCode.BadRequest, ErrorDescription = "Bad Request..." };
        }

        [HttpPost]
        public HttpResponseMessage Post(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
            //return Request.CreateResponse(HttpStatusCode.OK, _employeeAppService.Create(employeeDto));
        }

        [HttpPut]
        public HttpResponseMessage Put(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            //_employeeAppService.Dispose();         
            base.Dispose(disposing);
        }

        #endregion
    }
}
