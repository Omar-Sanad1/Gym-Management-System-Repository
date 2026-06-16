using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AttendenceRecord : BaseEntity
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Category { get; set; }
        public string AttendanceType { get; set; }
        public int FitnessClassID { get; set; } // ==> FK
        public FitnessClass FitnessClass { get; set; } // ==> Navigation Property
        public int MemberID { get; set; } // ==> FK
        public Member Member { get; set; } // ==> Navigation Property
    }
}
