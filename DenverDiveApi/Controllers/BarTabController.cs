using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using BarTabService;
using Domain;
using Newtonsoft.Json;

namespace DenverDiveApi.Controllers
{
    public class BarTabController : ApiController
    {
        // GET api/bartab
        public IEnumerable<BarTab> Get()
        {
            var barTabService = new BarTabFileService();
            return barTabService.GetAll();
        }

        // POST api/bartab
        public void Post([FromBody]BarTab barTab)
        {
            var barTabService = new BarTabFileService();
            barTabService.Create(barTab);
        }
    }
}
