using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace WebApplication4.Controllers
{
    [ApiExceptionFilter]
    public class BaseController : Controller
    {
        public string MyMessage { get { return "Hello"; } }
    }

    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

        }
    }


    public class LoggingAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext httpContext)
        {
            //Logger.Log();
        }
    }

    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                //actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            }
        }
    }

    [Route("[controller]/[action]")]
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;

        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, IConfiguration configuration,
            ApplicationDbContext dbContext)
        {
            _signInManager = signInManager;
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Index");
        }

        public string StoreData()
        {
            //_dbContext.Roles.Include(e => e.ConcurrencyStamp).Query("User").inc

            var query = _dbContext.MyQuery<Employee>().Include("Department");

            //throw new Exception("Test exception");
            return "storedata";
        }

    }

    public static partial class CustomExtensions
    {
        public static IQueryable Query(this DbContext context, string entityName) =>
            context.Query(context.Model.FindEntityType(entityName).ClrType);

        public static IQueryable Query(this DbContext context, Type entityType) =>
            (IQueryable)((IDbSetCache)context).GetOrAddSet(context.GetDependencies().SetSource, entityType);

        public static IQueryable<T> MyQuery<T>(this DbContext context)
            where T : class
        {
            return context.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Query with dynamic Include
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="context">dbContext</param>
        /// <param name="includeProperties">includeProperties with ; delimiters</param>
        /// <returns>Constructed query with include properties</returns>
        public static IQueryable MyQuery<T>(this DbContext context, string includeProperties)
           where T : class
        {            
            string[] includes = includeProperties.Split(';');
            var query = context.Set<T>().AsQueryable();

            foreach (string include in includes)
                query = query.Include(include);

            return query;
        }

        //public static IQueryable<T> Query(this ApplicationDbContext context, T entityName)  where T : class =>
        //    context.Roles;
    }
}
