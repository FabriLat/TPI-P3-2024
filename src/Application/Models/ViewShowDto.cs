using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ViewShowDto
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; } 
        public string RunTime { get; set; }

        public string StartTime { get; set; }


        public ViewShowDto(int id, string title, string runTime, string startTime) 
        {
            Id=id;
            MovieTitle=title;
            RunTime=runTime;
            StartTime=startTime;
        }
    }
}
