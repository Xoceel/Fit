using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Models
{
    class Workout
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Exercise> Exercises { get; set; }

    }
}
