using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Models
{
    public class MultiModelPage
    {
        public string PhotoUrl { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string TempBadge { get; set; } 
         
        public int AssignTime { get; set; }
        //==============
        public string SignOut { get; set; }
        

    }
}
