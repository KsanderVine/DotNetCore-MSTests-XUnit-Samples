using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineCalc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class CalcController : ControllerBase
    {
        [HttpPost("[action]")]
        public ActionResult<double> Sum([FromBody] CalcABRequest request)
        {
            double result = request.A + request.B;

            if (double.IsInfinity(result))
                throw new Exception($"Result [{result}] out of range");

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<double> Difference([FromBody] CalcABRequest request)
        {
            return request.A - request.B;
        }

        [HttpPost("[action]")]
        public ActionResult<double> Multiplication([FromBody] CalcABRequest request)
        {
            double result = request.A * request.B;

            if (double.IsInfinity(result))
                throw new Exception($"Result [{result}] out of range");

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<double> Division([FromBody] CalcABRequest request)
        {
            if (request.B == 0)
                throw new DivideByZeroException();

            return request.A / request.B;
        }

        [HttpPost("[action]")]
        public ActionResult<double> Power([FromBody] CalcABRequest request)
        {
            double result = Math.Pow(request.A, request.B);

            if (double.IsInfinity(result))
                throw new Exception($"Result [{result}] out of range");

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<double> Sqrt([FromBody] CalcARequest request)
        {
            return Math.Sqrt(request.A);
        }

        [HttpPost("[action]")]
        public ActionResult<double> Remainder([FromBody] CalcABRequest request)
        {
            return request.A % request.B;
        }
    }

    public record CalcARequest(double A);
    public record CalcABRequest(double A, double B);
}