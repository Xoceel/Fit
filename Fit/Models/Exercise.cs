using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Models
{
    class Exercise
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }

        public Exercise(int id, string name, int sets, int reps, float weight)
        {
            Id = id;
            ExerciseName = name;
            Sets = sets;
            Reps = reps;
            Weight = weight;
        }
    }
}
