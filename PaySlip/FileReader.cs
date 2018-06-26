using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PaySlip
{
    public static class FileReader
    {
        public static string ReadFromJSONFile(string filePath)
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                var jsonContent = file.ReadToEnd();
                return jsonContent;
            }
        }

//        public static object ReadFromCSVFile(string filePath)
//        {
//        }
    }
}