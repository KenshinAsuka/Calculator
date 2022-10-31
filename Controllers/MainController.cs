using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {

        [HttpGet("calculate")]
        public double Calculate(string sum)
        {
            double total = 0;

            try
            {
            
                List<double> numList = new List<double>();

                List<bool> isBracket = new List<bool>();

                List<char> oper = new List<char>();

                string newNum = "";
                int len = sum.Length;
                int l = 1;
                bool inBracket = false;
                //bool endBracket = false;

                foreach (var s in sum)
                {
                    
                    if(Char.IsDigit(s))
                    {
                        newNum = newNum + s.ToString();

                        
                    }
                    else if(s == '.')
                    {
                        newNum = newNum + s.ToString();
                    }
                    else if (s == '(')
                    {
                        inBracket = true;
                    }
                    else if (s == ')')
                    {
                        inBracket= false;
                    }
                    else if(s == '+' || s == '-' || s == '*' || s == '/')
                    {
                        oper.Add(s);

                        
                    }
                    else if (s == ' ')
                    {
                        if(newNum != "")
                        {
                            numList.Add(Convert.ToDouble(newNum));

                            if(inBracket)
                                isBracket.Add(true);
                            else
                                isBracket.Add(false);

                            newNum = "";

                            
                        }
                    }

                    if (l == len)
                    {
                        if (!String.IsNullOrEmpty(newNum))
                        {
                            numList.Add(Convert.ToDouble(newNum));
                            isBracket.Add(false);
                        }
                    }
                        

                    l++;
                }

                double bracket = 0;
                double nonBracket = 0;
                int counter = -1;

                for(int n = 0; n < numList.Count; n++)
                {
                    if (isBracket[n] == true)
                    {
                        if((n == 0 || n == 1) && counter == -1)
                        {
                            bracket = numList[n];
                            counter = n;
                        }
                        else
                        {
                            if (oper[counter] == '+')
                            {
                                bracket = bracket + numList[n];
                            }
                            else if (oper[counter] == '-')
                            {
                                bracket = bracket - numList[n];
                            }
                            else if (oper[counter] == '*')
                            {
                                bracket = bracket * numList[n];
                            }
                            else if (oper[counter] == '/')
                            {
                                bracket = bracket / numList[n];
                            }


                        }
                       

                    }
            
                     
                }

                int counter2 = -1;

                for(int k = 0; k < numList.Count; k++)
                {
                 
                        if (isBracket[k] == false)
                        {
                            if (counter2 == -1)
                            {
                                nonBracket = numList[k];
                                counter2 = k - 1;

                            if (counter2 == -1)
                                counter2 = 0;
                            }
                            else
                            {
                                if (oper[counter2] == '+')
                                {
                                    nonBracket = nonBracket + numList[k];
                                }
                                else if (oper[counter2] == '-')
                                {
                                    nonBracket = nonBracket - numList[k];
                                }
                                else if (oper[counter2] == '*')
                                {
                                    nonBracket = nonBracket * numList[k];
                                }
                                else if (oper[counter2] == '/')
                                {
                                    nonBracket = nonBracket / numList[k];
                                }

                               counter2++;
                            }


                        }

                    
                }

                if(counter > -1)
                {


                    if(counter == 0)
                    {
                        counter++;

                        if (oper[counter] == '+')
                        {
                            total = bracket + nonBracket;
                        }
                        else if (oper[counter] == '-')
                        {
                            total = bracket - nonBracket;
                        }
                        else if (oper[counter] == '*')
                        {
                            total = bracket * nonBracket;
                        }
                        else if (oper[counter] == '/')
                        {
                            total = bracket / nonBracket;
                        }
                    }
                    else if(counter == 1)
                    {
                        counter--;

                        if (oper[counter] == '+')
                        {
                            total = nonBracket + bracket;
                        }
                        else if (oper[counter] == '-')
                        {
                            total = nonBracket - bracket;
                        }
                        else if (oper[counter] == '*')
                        {
                            total = nonBracket * bracket;
                        }
                        else if (oper[counter] == '/')
                        {
                            total = nonBracket / bracket;
                        }
                    }

                    
                }
                else
                {
                    total = nonBracket;
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
