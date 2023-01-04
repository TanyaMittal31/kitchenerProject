using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Models
{
    public class Report
    {
        public string Name { get; set; } = null!;
        public string TempBadge { get; set; } 
        public string SignIn { get; set; }
        public int AssignTime { get; set; }
        public string SignOut { get; set; }

        // =====================================
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Status { get; set; }
        public string PhotoUrl { get; set; } = null!;
    }
}
