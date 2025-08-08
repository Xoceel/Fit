using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Models
{
    class ExerciseRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ExerciseName { get; set; }
        public float Weight { get; set; }
        public string MeasurementUnit { get; set; }
        public int Repetitions { get; set; }
        public string MuscleGroup { get; set; }
    }
}
