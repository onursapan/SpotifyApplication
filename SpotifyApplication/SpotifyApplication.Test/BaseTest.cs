using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace SpotifyApplication.Test
{
    public class BaseTest
    {
        private readonly ITestOutputHelper _output;
        protected BaseTest(ITestOutputHelper output) => _output = output;
        protected void WriteOutputAsJson(object value) => _output.WriteLine(JsonConvert.SerializeObject(value));

    }
}
