using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace WebApplication2.Controllers
{
    public class AccountTransaction1
    {
        public int? Account_Number { get; set; }

        public decimal? Deposit { get; set; }

        public decimal? Withdrawal { get; set; }

        public decimal? Account_Balance { get; set; }

        public string Date { get; set; }
        public decimal? Amount { get; internal set; }
    }

    public class AccountTransaction2
    {
        public int? Account_Number { get; set; }

        public decimal? Deposit { get; set; }

        public decimal? Withdrawal { get; set; }

        public decimal? Account_Balance { get; set; }

        public string Date { get; set; }
        public decimal? Amount { get; internal set; }
    }

    public class AccountTransaction3
    {
        public int? Account_Number { get; set; }

        public decimal? Deposit { get; set; }

        public decimal? Withdrawal { get; set; }

        public decimal? Account_Balance { get; set; }

        public string Date { get; set; }

    }

    public class AccountTransaction
    {
        public int? Account_Number { get; set; }

        public decimal? Deposit { get; set; }

        public decimal? Withdrawal { get; set; }

        public decimal? Account_Balance { get; set; }

        public string Date { get; set; }

    }

    //public class TestDbContext : DbContext

    public class TokenAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            string token = Convert.ToString(filterContext.RouteData.Values["token"]);
            // do your authentication stuff            
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            throw new NotImplementedException();
        }
    }

    [TokenAuthenticationFilter]
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController()
        {
            
        }

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult Download (string filename)
        {
            return View();
        }        


            public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            List<AccountTransaction1> listAccountTransaction1 = new List<AccountTransaction1>();
            List<AccountTransaction2> listAccountTransaction2 = new List<AccountTransaction2>();
            List<AccountTransaction3> listAccountTransaction3 = new List<AccountTransaction3>();

            var inOut = listAccountTransaction1.Select(w => new AccountTransaction
            {
                Account_Number = w.Account_Number,
                Account_Balance = (decimal?)0M,
                Deposit = (decimal?)null,
                Withdrawal = (decimal?)w.Amount,
                Date = w.Date
            }).Concat(listAccountTransaction2.Select(d => new AccountTransaction
            {
                Account_Number = d.Account_Number,
                Deposit = (decimal?)d.Amount,
                Withdrawal = (decimal?)null,
                Date = d.Date
            })).OrderBy(r => r.Date)
                .Concat(listAccountTransaction3.Select(e => new AccountTransaction
                {
                    Account_Number = e.Account_Number,
                    Account_Balance = (decimal?)e.Account_Balance
                }));

            return View();
        }

        [HttpPost]
        public ActionResult CaptureUserData(string IdentityNo, string FullName,
    string Dob, string Gender, string PhoneNo, string PhoneNo1, string Email, string Category, string Password)
        {

            return Json(new { IdentityNo = IdentityNo });
        }

    }
}
