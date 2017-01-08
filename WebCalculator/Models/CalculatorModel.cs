/* CalculatorModel.cs
 * Authors: Anthony Wolf
 * Date: 1-8-2017
 * The model which will be used for WebCalculator requests and responses
 */

using System.Web.Mvc;
using WebCalculator.Infrastructure.ModelBinders;

namespace WebCalculator.Models
{
    public enum Operation
    {
        Add, Subtract, Multiply, Divide
    }

    [ModelBinder(typeof(OperationModelBinder))]
    public class CalculatorModel
    {
        public decimal? LOperand { get; set; }
        public decimal? ROperand { get; set; }
        public Operation? Operator { get; set; }
    }
}