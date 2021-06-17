using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkCutter.Models
{
    public class BaseModel
    {
        public BaseModel(string title = "")
        {
            Title = title;
        }

        public string Title { get; set; }
    }

}
