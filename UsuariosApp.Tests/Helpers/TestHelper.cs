using Azure.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Tests.Helpers
{
    public class TestHelper
    {
        public static HttpClient CreateClient()
        {
            return new WebApplicationFactory<Program>().CreateClient();
        }

        public static StringContent CreateContent(Object obj)
        {            
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}
