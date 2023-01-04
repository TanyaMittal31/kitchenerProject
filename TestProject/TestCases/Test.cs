using Business.Layer.Services;
using Data.Access.Layer.Models;
using Data.Access.Layer.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.TestCases
{
    public class Test
    {
        
        private readonly Mock<IGenricRepository> repoTest;

        public Test()
        {
            repoTest = new Mock<IGenricRepository>();


        }
        public List<Gaurd> getGuardData()
        {
            List<Gaurd> guards = new List<Gaurd>
             {
             new Gaurd
             {
             FirstName = "Tanya",
             LastName = "Agrawal",
             EmpCode = 107,
             SignIn = DateTime.Now,
             TempBadge = "abc@defg",
             }
             };
            return guards;
        }

        /*================== SignInBadge ====================*/
        [Fact]
        public void SignInBadge_STest()
        {
            var f = getGuardData();

            repoTest.Setup(x => x.SignInBadge(f[0].FirstName, f[0].LastName, f[0].EmpCode)).Returns(f);

            var test = new GuardService(repoTest.Object);

            var result = test.SignInBadge(f[0].FirstName, f[0].LastName, f[0].EmpCode);

            Assert.NotNull(result);


        }

        [Fact]

        public void SignInBadge_FTest()
        {
            var f = getGuardData();

            repoTest.Setup(x => x.SignInBadge(f[0].FirstName, f[0].LastName, f[0].EmpCode)).Returns(f);

            var test = new GuardService(repoTest.Object);

            var result = test.SignInBadge(null, f[0].LastName, 2);

            Assert.Null(result);
        }

        /*================== SignOutPage ====================*/
        [Fact]
        public void SignOutPage_STest()
        {
            var f = getGuardData();

            repoTest.Setup(x => x.SignOutPage(f[0].TempBadge)).Returns(f);

            var test = new GuardService(repoTest.Object);

            var result = test.SignOutPage(f[0].TempBadge);

            Assert.NotNull(result);


        }

        [Fact]

        public void SignOutPage_FTest()
        {
            var f = getGuardData();

            repoTest.Setup(x => x.SignOutPage(f[0].TempBadge)).Returns(f);

            var test = new GuardService(repoTest.Object);

            var result = test.SignOutPage(null);

            Assert.Null(result);
        }
    }


}

