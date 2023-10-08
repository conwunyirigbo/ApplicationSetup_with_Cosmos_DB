using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternAppl.Domain.Entities
{
    public class ApplicationSetup
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public Personalinfo PersonalInfo { get; set; }
        public AdditionalProgramInfo AdditionalProgramInfo { get; set; }
        public List<WorkFlow> Stages { get; set; }
    }
}
