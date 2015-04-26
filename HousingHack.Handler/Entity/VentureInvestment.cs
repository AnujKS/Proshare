using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingHack.Handler.Entity
{
    public class VentureInvestment
    {
        public int Id { get; set; }
        public double Investment { get; set; }
        public int UserId { get; set; }
        public int VentureId { get; set; }
    }
}
