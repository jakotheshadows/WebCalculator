/*  OperationModelBinder.cs
 *  Authors: Anthony Wolf
 *  Date: 1/8/2017
 *  Implementation of a model binder for the Operation enum component of the Calculator model
 */

using System;
using System.Web;
using System.Web.Mvc;
using WebCalculator.Models;

namespace WebCalculator.Infrastructure.ModelBinders
{
    public class OperationModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if(bindingContext.ModelType == typeof(CalculatorModel))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;
                string operationRaw = request.Form.Get("Operator");
                Operation res;
                switch(operationRaw)
                {
                    case "+":
                        res = Operation.Add;
                        break;
                    case "-":
                        res = Operation.Subtract;
                        break;
                    case "*":
                        res = Operation.Multiply;
                        break;
                    case "/":
                        res = Operation.Divide;
                        break;
                    default:
                        throw new NotImplementedException();
                }
                decimal LOperand = Decimal.Parse(request.Form.Get("LOperand"));
                decimal ROperand = Decimal.Parse(request.Form.Get("ROperand"));
                return new CalculatorModel() { LOperand = LOperand, ROperand = ROperand, Operator = res };
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}