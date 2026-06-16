using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class BranchToReturnDTO
    {
        public string BranchName { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }
        public string OperatingHours { get; set; }
        public string CurrentOperationalStatus { get; set; }
    }
}
