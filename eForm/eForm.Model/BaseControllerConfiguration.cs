using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace eForm.Model
{
    public class BaseControllerConfiguration
    {
        public IConfiguration Configuration { get; set; }

        public string ConnectionString { get; set; }
    }
}
