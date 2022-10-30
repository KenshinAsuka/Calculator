using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {

        [HttpGet]
        public double Calculate(string sum)
        {
            double total = 0;

            try
            {
                List<double> digit = new List<double>();

                double dg = 0;

                double temp = 0;

                double bdg = 0;

                bool bracket = false;

                foreach (var str in sum)
                {
                    if (str == '(')
                    {
                        bdg = 0;
                        bracket = true;
                    }
                    else if (str == ')')
                    {
                        digit.Add(bdg);
                        bdg = 0;
                        temp = 0;
                        bracket= false;
                    }
                    else if (str == '+')
                    {
                        if(bracket)
                        {
                            bdg = temp + bdg;
                        }
                        else
                        {
                            dg = temp + dg;
                            temp = 0;
                        }
                        
                    }
                    else if (str == '-')
                    {
                        if (bracket)
                        {

                        }
                        else
                        {
                            dg = temp - dg;
                            temp = 0;
                        }
                    }
                    else if (str == '*')
                    {
                        dg = temp * dg;
                        temp = 0;
                    }
                    else if (str == '/')
                    {
                        dg = temp / dg;
                        temp = 0;
                    }
                    else if(str == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        temp = Convert.ToDouble(str.ToString());
                        dg = temp;

                        if(bracket == false)
                            digit.Add(dg);
                        else
                            bdg = temp;
                    }
                }

                foreach (var d in digit)
                {
                    total = total + d;
                }

                return total;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
