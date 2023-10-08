using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternAppl.Domain.Entities
{
    public class Personalinfo
    {
        public bool CoverImageRequired { get; set; }
        public bool ShowPhone { get; set; }
        public bool PhoneIsInternal { get; set; }
        public bool ShowNationality { get; set; }
        public bool NationalityIsInternal { get; set; }
        public bool ShowResidence { get; set; }
        public bool ResidenceIsInternal { get; set; }
        public bool ShowIDNo { get; set; }
        public bool IDNoIsInternal { get; set; }
        public bool ShowDob { get; set; }
        public bool DobISInternal { get; set; }
        public bool ShowGender { get; set; }
        public bool GenderIsInternal { get; set; }
        public bool EducationIsRequired { get; set; }
        public bool ShowEducation { get; set; }
        public bool WorkIsRequired { get; set; }
        public bool ShowWork { get; set; }
        public List<AdditionalQuestions> AdditionalQuestions { get; set; }

    }

    public class AdditionalQuestions
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        public string MaxChoiceAllowed { get; set; }

    }
}
