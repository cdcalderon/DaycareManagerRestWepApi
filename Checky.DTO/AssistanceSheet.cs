using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checky.DTO
{
    public class AssistanceSheet
    {
        public int Id { get; set; }

        public DateTime CheckInTime { get; set; }

        public DateTime CheckOutTime { get; set; }

        public int KidId { get; set; }

        public int CheckIntParentId { get; set; }

        public int CheckOutParentId { get; set; }

        public string OtherCheckInRelative { get; set; }

        public string OtherCheckOutRelative { get; set; }
    }
}
