using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Models
{
    public class WorkoutEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        //not working in the db
        //public List<ExerciseEntry> Exercises { get; set; }

        // For printing out the list of exercises just debug use rn
        //public string ExerciseSummary
        //{
        //    get
        //    {
        //        return string.Join(", ", Exercises.Select(e => e.ExerciseName));
        //    }
        //}

        //public override string ToString()
        //{
        //    return $"{Id}, {Date}, {ExerciseSummary}";
        //}

    }
}
