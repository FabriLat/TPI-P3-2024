using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Show
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MovieId { get; set; }  // Foreign Key
        public TimeSpan RunTime { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int SeatsAvailable { get; set; }


        public Show() { }

        public Show(TimeSpan runTime, TimeSpan startTime) 
        {
            RunTime = runTime;
            StartTime = startTime;
            EndTime = StartTime.Add(RunTime);
            SeatsAvailable = 3; //numero chico por ahora para testeo. Una vez controlado que funciona modificar a 100
        }
    }
}
