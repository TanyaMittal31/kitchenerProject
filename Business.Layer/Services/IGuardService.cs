using Data.Access.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    public interface IGuardService
    {
        public IEnumerable<Gaurd> SignInBadge(string fname, string lname, int ecode);
        public IEnumerable<Gaurd> SignOutBadge(int Id);
        public IEnumerable<Gaurd> GetBadges();
        public IEnumerable<Report> GetBadgeQueue();

        //============ changes ===========
        public IEnumerable<Gaurd> SignOutPage(string TempBadge);

        public IEnumerable<MultiModelPage> GetMultiModels();
        /*public IEnumerable<Report> GetReports();*/

        //==========================
        public IEnumerable<Gaurd> GetNReports();
        public IEnumerable<Gaurd> GetReports(DateTime StartDate, DateTime EndDate, string FirstName, string LastName, string Status);
    }
}
