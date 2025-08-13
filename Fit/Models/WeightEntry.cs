using SQLite;

namespace Fit.Models
{
    public class WeightEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Weight { get; set; }
    }
}
