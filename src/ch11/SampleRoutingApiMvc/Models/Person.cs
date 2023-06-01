using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;

namespace SampleRoutingApiMvc.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
