using System;

namespace SwaggerAPI.Models
{
    public class ProducerVersion :  Attribute
    {
        public string Version { get; set; }
        public ProducerVersion(string value)
        {
            Version = value;
        }
    }
}
