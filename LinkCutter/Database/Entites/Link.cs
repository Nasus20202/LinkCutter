using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinkCutter
{
    public class Link
    {
        public Link()
        {
            TimeAdded = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }


        public string Code { get; set; }
        public string Url { get; set; }
        public int TimesUsed { get; set; }

        public DateTime TimeAdded { get; set; }
    }
}
