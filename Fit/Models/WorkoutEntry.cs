using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Models
{
    class WorkoutEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<ExerciseEntry> Exercises { get; set; }

    }
}
