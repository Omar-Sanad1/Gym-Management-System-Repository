using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ReviewToReturnDTO
    {
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int FitnessClassID { get; set; } 
        public string TrainerName { get; set; } 
        public string MemberName { get; set; } 
    }
}
