using eForm.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForm.Api.Base
{
    public class BaseController : Controller
    {
        protected BaseControllerConfiguration _baseControllerConfiguration;
        protected IConfiguration _configuration;
      

        public BaseController(BaseControllerConfiguration config)
        {
            _baseControllerConfiguration = config;
            _configuration = config.Configuration;
        }
    }
}
