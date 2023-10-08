using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternAppl.Domain.Entities
{
    public class ApiResponse
    {
        public string Create_Id { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public bool Success { get; set; }
    }
}
