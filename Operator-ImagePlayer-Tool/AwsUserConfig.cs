using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Operator_ImagePlayer_Tool
{
    internal class AwsUserConfig
    {
        public string AccessKey { get; set; }       // required
        public string SecretKey { get; set; }       // required
        public string RoleArn { get; set; }         // required
        public string Region { get; set; }          // required


        public static AwsUserConfig LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("AWS config file not found.", filePath);

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<AwsUserConfig>(json);
        }
    }
}
