using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Models
{
    class ExerciseEntry
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }

        public ExerciseEntry()
        {

        }

        public ExerciseEntry(int id, string exerciseName, int sets, int reps, float weight)
        {
            Id = id;
            ExerciseName = exerciseName;
            Sets = sets;
            Reps = reps;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{ExerciseName}, {Sets}, {Reps}, {Weight}";
        }
    }
}
