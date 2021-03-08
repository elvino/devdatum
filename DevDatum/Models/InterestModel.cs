using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDatum.Models
{
    public class InterestModel
    {
        public InterestModel(){}

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal FinalValue { get; set; }
        public decimal InitialValue { get; set; }
        public int Time { get; set; }
    }
}
