using SQLite;

namespace Fit.Models
{
    public class CalorieEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carbs { get; set; }
    }
}
