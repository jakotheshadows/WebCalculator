using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebCalculator.Infrastructure.ModelBinders;
using WebCalculator.Models;

namespace WebCalculator
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //register the model binder
            ModelBinders.Binders.Add(typeof(Operation), new OperationModelBinder());
        }
    }
}
