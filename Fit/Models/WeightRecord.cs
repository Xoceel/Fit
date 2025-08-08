using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Models
{
    class WeightRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Weight { get; set; }
        public string MeasurementUnit { get; set; }
    }
}
