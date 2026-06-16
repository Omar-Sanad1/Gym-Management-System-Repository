using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AttendenceRecordToReturnDTO
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Category { get; set; }
        public string AttendanceType { get; set; }
        public int FitnessClassID { get; set; } 
        public string MemberName { get; set; } 
    }
}
