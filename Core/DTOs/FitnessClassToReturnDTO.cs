using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class FitnessClassToReturnDTO
    {
        public string ClassName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Schedule { get; set; }
        public int Duration { get; set; }
        public int MaximumCapacity { get; set; }
        public string AvailabilityStatus { get; set; }
        public string AssignedTrainer { get; set; }
        public string TrainerName { get; set; } 
        public int BranchID { get; set; } 
    }
}
