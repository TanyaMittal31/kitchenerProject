using Data.Access.Layer.Models;
using Data.Access.Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    public class GuardService : IGuardService
    {
        private readonly IGenricRepository _repo;

        public GuardService(IGenricRepository repo)
        {
            this._repo = repo;
        }

        public IEnumerable<Gaurd> GetBadges()
        {
          return _repo.GetBadges();
        }

        public IEnumerable<Gaurd> SignInBadge(string fname, string lname, int ecode)
        {
            if(fname == null || ecode == null)
            {
                return null;
            }
            return _repo.SignInBadge(fname,lname,ecode);
        }

        public IEnumerable<Gaurd> SignOutBadge(int Id)
        {
            return (_repo.SignOutBadge(Id));
        }

        //============ changes ===========
        public IEnumerable<MultiModelPage> GetMultiModels()
        {
            return (_repo.GetMultiModels());
        }

        /*public IEnumerable<Report> GetReports()
        {
            return _repo.GetReports();
        }*/

        public IEnumerable<Gaurd> SignOutPage(string TempBadge)
        {
            if(TempBadge == null)
            {
                return null;
            }
            return _repo.SignOutPage(TempBadge);
        }
        //==========================
        public IEnumerable<Gaurd> GetNReports()
        {
            return _repo.GetNReports();
        }
        public IEnumerable<Gaurd> GetReports(DateTime StartDate, DateTime EndDate, string FirstName, string LastName, string Status)
        { 
            //================
            return _repo.GetReports(StartDate,EndDate,FirstName,LastName,Status);
        }

        public IEnumerable<Report> GetBadgeQueue()
        {
            return _repo.GetBadgeQueue();
        }
    }
}
