using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Branch : BaseEntity
    {
        public string BranchName { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }
        public string OperatingHours { get; set; }
        public string CurrentOperationalStatus { get; set; }
        public List<Trainer> Trainers { get; set; } = new();
        public List<Member> Members { get; set; } = new();
        public List<FitnessClass> FitnessClasses { get; set; } = new();


    }
}
