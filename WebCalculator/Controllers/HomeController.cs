/* HomeController.cs
 * Authors: Anthony Wolf
 * Date: 1/8/2017
 * Handles all calculation requests from the client, and returns results in the LOperand member of the CalculatorModel as Json
 */

using System;
using System.Web.Mvc;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DoCalculator()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public ActionResult DoCalculator(CalculatorModel model)
        {
            switch(model.Operator)
            {
                case Operation.Add:
                    model.LOperand += model.ROperand;
                    model.ROperand = null;
                    break;
                case Operation.Divide:
                    if (model.ROperand == 0)
                    {
                        model.LOperand = null;
                        model.ROperand = null;
                        model.Operator = null;
                        break;
                    }
                    model.LOperand /= model.ROperand;
                    break;
                case Operation.Multiply:
                    model.LOperand *= model.ROperand;
                    model.ROperand = null;
                    break;
                case Operation.Subtract:
                    model.LOperand -= model.ROperand;
                    model.ROperand = null;
                    break;
                default:
                    throw new NotImplementedException();
            }
            return Json(model);
        }
    }
}