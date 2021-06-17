using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkCutter.Models
{
    public class LinkInfoModel : BaseModel
    {
        public LinkInfoModel() : base()
        {

        }

        public Link Link { get; set; }
    }
}
