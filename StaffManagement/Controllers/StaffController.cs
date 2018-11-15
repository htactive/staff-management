using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;

namespace StaffManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/Staff")]
    public class StaffController : Controller
    {
        [HttpPost]
        [Route("Search")]
        public StaffFilterResult Search(FilterStaffModel model)
        {
            var rows = new List<StaffModel>();
            for (int i = 0; i < 10; i++)
            {
                rows.Add(new StaffModel()
                {
                    email = "email" + i,
                    firstname = "firstname" + i,
                    lastname = "lastname" + i,
                    phone = "phone" + i,
                    Id = i
                });
            }
            return new StaffFilterResult()
            {
                rows = rows,
                total = 10
            };
        }

        [HttpGet("{id}", Name = "Get")]
        public StaffModel Get(int id)
        {
            return new StaffModel()
            {
                Id = id
            };
        }

        [HttpPost]
        [Route("create")]
        public StaffModel Create(StaffModel model)
        {
            return model;
        }

        [HttpPost]
        [Route("update")]
        public StaffModel Update(int id, StaffModel model)
        {
            model.Id = id % 2 == 1 ? 100 : 200;
            return model;
        }

        [HttpPost("{id}")]
        [Route("delete")]
        public ApiResponse<bool> Delete(int id)
        {
            return new ApiResponse<bool>()
            {
                data = id % 2 == 1,
                success = true
            };
        }
    }
}
