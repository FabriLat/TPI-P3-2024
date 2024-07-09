using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Show> Shows { get; set; }


        public Movie()
        {
            Shows = new List<Show>();
        }

        public Movie (string title)
        {
            Title = title;
            Shows = new List<Show> ();
        }
    }
}
