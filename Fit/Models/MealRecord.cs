using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Models
{
    class MealRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public List<string> Foods { get; set; }

    }
}
