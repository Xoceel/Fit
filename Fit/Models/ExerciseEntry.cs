using SQLite;

namespace Fit.Models
{
    public class ExerciseEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }

        public ExerciseEntry()
        {

        }

        public ExerciseEntry(int id, DateTime date, string exerciseName, int sets, int reps, float weight)
        {
            Id = id;
            Date = date;
            ExerciseName = exerciseName;
            Sets = sets;
            Reps = reps;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{ExerciseName}, {Date}, {Sets}, {Reps}, {Weight}";
        }
    }
}
