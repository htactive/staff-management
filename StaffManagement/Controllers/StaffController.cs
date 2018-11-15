using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.DataContext;
using StaffManagement.Models;

namespace StaffManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/Staff")]
    public class StaffController : Controller
    {
        private IStaffContext staffContext;
        public StaffController(IStaffContext staffContext)
        {
            this.staffContext = staffContext;
        }
        [HttpPost]
        [Route("Search")]
        public async Task<StaffFilterResult> Search(FilterStaffModel model)
        {
            return await staffContext.Filter(model.page - 1, model.rows);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ApiResponse<bool>> Create(StaffModel model)
        {
            await staffContext.Create(model);
            return new ApiResponse<bool>()
            {
                success = true
            };
        }

        [HttpPost]
        [Route("update")]
        public async Task<ApiResponse<bool>> Update(int id, StaffModel model)
        {
            model.Id = id;
            await staffContext.Update(model);
            return new ApiResponse<bool>()
            {
                success = true
            };
        }

        [HttpPost("{id}")]
        [Route("delete")]
        public async Task<ApiResponse<bool>> Delete(int id)
        {
            await staffContext.Delete(id);
            return new ApiResponse<bool>()
            {
                success = true
            };
        }
    }
}
