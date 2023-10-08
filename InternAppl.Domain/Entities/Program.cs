using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternAppl.Domain.Entities
{
    public class Program
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public List<string> Skills { get; set; }
        public string Benefits { get; set; }
        public string Criteria { get; set; }
        public AdditionalProgramInfo AdditionalProgramInfo { get; set; }
    }

    public class AdditionalProgramInfo
    {
        public string ProgramType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string Duration { get; set; }
        public string Location { get; set; }
        public string MinQual { get; set; }
        public int MaxApplications { get; set; }
        public bool IsFullyRemote { get; set; }

    }
}
