using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternAppl.Domain.Entities
{
    public class WorkFlow
    {
        public string Id { get; set; }
        public string StageName { get; set; }
        public string Type { get; set; }
        public bool ShowCandidate { get; set; }
    }
}
