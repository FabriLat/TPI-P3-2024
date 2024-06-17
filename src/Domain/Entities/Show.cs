using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Show
    {
        public string MovieName { get; set; }

        public TimeSpan RunTime { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int SeatsAvailable { get; set; }


        public Show(string movieName, TimeSpan runTime, TimeSpan startTime) 
        {
            MovieName = movieName;
            RunTime = runTime;
            StartTime = startTime;
            EndTime = StartTime.Add(RunTime);
            SeatsAvailable = 3; //numero chico por ahora para testeo. Una vez controlado que funciona modificar a 100
        }
    }
}
