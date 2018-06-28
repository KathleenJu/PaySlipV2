using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PaySlip.FilesConfig
{
    public class BasicFormFileConfig : FileConfigInterface
    {
        public IEnumerable Foo(string formFileContent)
        {
            var form = JsonConvert.DeserializeObject<Dictionary<string, string>>(formFileContent);
            return form;
        }
    }
}