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
        public IEnumerable<StaffModel> Search([FromBody]FilterStaffModel model)
        {
            return new List<StaffModel>() {
                new StaffModel(){
                    Department = model.Department,
                    Education = model.Education,
                    FullName = model.FullName,
                    Id= 100
                }
            };
        }

        [HttpGet("{id}", Name = "Get")]
        public StaffModel Get(int id)
        {
            return new StaffModel()
            {
                Department = "d111",
                Education = "sdsd",
                FullName = "sdsdsdsd",
                Id = id
            };
        }

        // POST: api/Staff
        [HttpPost]
        public StaffModel Post([FromBody]StaffModel model)
        {
            model.Id += 10;
            return model;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return id % 2 == 1;
        }
    }
}
