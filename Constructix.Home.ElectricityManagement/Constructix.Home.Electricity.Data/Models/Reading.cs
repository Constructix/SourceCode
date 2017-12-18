using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructix.Home.ElectricityReading.Data.Models
{
    public class Reading
    {
        public Reading()
        {
          
        }
        [Key]
        public int Id { get; set; }
        public int Value { get; }
        public DateTime Recorded { get; }
        
    }

    public class ReadingRepository
    {
        
    }
}
