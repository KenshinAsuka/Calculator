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
                int j1 = sum.IndexOf("(");
                int j2 = sum.IndexOf(") )");
                int j3 = sum.IndexOf(")");

                //Response.Write(j1.ToString() + " - " + j2.ToString() + " " + j3.ToString() + "<br/>");

                List<double> numList = new List<double>();

                List<int> bracketPosition = new List<int>();



                List<char> oper = new List<char>();

                string newNum = "";
                int len = sum.Length;
                int l = 0;
                bool front = false;
                bool middle = false;
                bool back = false;
                //bool endBracket = false;

                foreach (var s in sum)
                {

                    if (Char.IsDigit(s))
                    {
                        newNum = newNum + s.ToString();


                    }
                    else if (s == '.')
                    {
                        newNum = newNum + s.ToString();
                    }
                    else if (s == '(')
                    {
                        bracketPosition.Add(l);
                    }
                    else if (s == ')')
                    {
                        bracketPosition.Add(l);
                    }
                    else if (s == '+' || s == '-' || s == '*' || s == '/')
                    {
                        oper.Add(s);


                    }
                    else if (s == ' ')
                    {
                        if (newNum != "")
                        {
                            numList.Add(Convert.ToDouble(newNum));

                            newNum = "";

                        }
                    }

                    if (l == len - 1)
                    {
                        if (!String.IsNullOrEmpty(newNum))
                        {
                            numList.Add(Convert.ToDouble(newNum));

                        }
                    }


                    l++;
                }



                int counter2 = oper.Count;
                int mainLen = numList.Count;
                if (mainLen == 2)
                {
                    if (oper[0] == '+')
                    {
                        total = numList[0] + numList[1];
                    }
                    else if (oper[0] == '-')
                    {
                        total = numList[0] - numList[1];
                    }
                    else if (oper[0] == '*')
                    {
                        total = numList[0] * numList[1];
                    }
                    else if (oper[0] == '/')
                    {
                        total = numList[0] / numList[1];
                    }
                }
                else if (mainLen == 3)
                {
                    if (bracketPosition.Count > 0)
                    {
                        foreach (var b in bracketPosition)
                        {
                            if (b == 0)
                            {
                                front = true;
                                back = false;
                                break;
                            }
                            else
                            {
                                back = true;
                                front = false;
                                break;
                            }
                        }

                        if (front == true)
                        {
                            if (oper[0] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] + numList[1]) + numList[2];
                            }
                            else if (oper[0] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] + numList[1]) - numList[2];
                            }
                            else if (oper[0] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] + numList[1]) * numList[2];
                            }
                            else if (oper[0] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] + numList[1]) / numList[2];
                            }
                            else if (oper[0] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] - numList[1]) + numList[2];
                            }
                            else if (oper[0] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] - numList[1]) - numList[2];
                            }
                            else if (oper[0] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] - numList[1]) * numList[2];
                            }
                            else if (oper[0] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] - numList[1]) / numList[2];
                            }
                            else if (oper[0] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] * numList[1]) + numList[2];
                            }
                            else if (oper[0] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] * numList[1]) - numList[2];
                            }
                            else if (oper[0] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] * numList[1]) * numList[2];
                            }
                            else if (oper[0] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] * numList[1]) / numList[2];
                            }
                            else if (oper[0] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] / numList[1]) + numList[2];
                            }
                            else if (oper[0] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] / numList[1]) - numList[2];
                            }
                            else if (oper[0] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] / numList[1]) * numList[2];
                            }
                            else if (oper[0] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] / numList[1]) / numList[2];
                            }
                        }
                        else if (back == true)
                        {
                            if (oper[0] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + (numList[1] + numList[2]);
                            }
                            else if (oper[0] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + (numList[1] - numList[2]);
                            }
                            else if (oper[0] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + (numList[1] * numList[2]);
                            }
                            else if (oper[0] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + (numList[1] / numList[2]);
                            }
                            else if (oper[0] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - (numList[1] + numList[2]);
                            }
                            else if (oper[0] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] - (numList[1] - numList[2]);
                            }
                            else if (oper[0] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] - (numList[1] * numList[2]);
                            }
                            else if (oper[0] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - (numList[1] / numList[2]);
                            }
                            else if (oper[0] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * (numList[1] + numList[2]);
                            }
                            else if (oper[0] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] * (numList[1] - numList[2]);
                            }
                            else if (oper[0] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * (numList[1] * numList[2]);
                            }
                            else if (oper[0] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * (numList[1] / numList[2]);
                            }
                            else if (oper[0] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] / (numList[1] + numList[2]);
                            }
                            else if (oper[0] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / (numList[1] - numList[2]);
                            }
                            else if (oper[0] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] / (numList[1] * numList[2]);
                            }
                            else if (oper[0] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] / (numList[1] / numList[2]);
                            }
                        }
                    }
                    else
                    {
                        if (oper[0] == '+' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] + numList[1] + numList[2];
                        }
                        else if (oper[0] == '+' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] + numList[1] - numList[2];
                        }
                        else if (oper[0] == '+' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] + numList[1] * numList[2];
                        }
                        else if (oper[0] == '+' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] + numList[1] / numList[2];
                        }
                        else if (oper[0] == '-' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] - numList[1] + numList[2];
                        }
                        else if (oper[0] == '-' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] - numList[1] - numList[2];
                        }
                        else if (oper[0] == '-' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] - numList[1] * numList[2];
                        }
                        else if (oper[0] == '-' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] - numList[1] / numList[2];
                        }
                        else if (oper[0] == '*' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] * numList[1] + numList[2];
                        }
                        else if (oper[0] == '*' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] * numList[1] - numList[2];
                        }
                        else if (oper[0] == '*' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] * numList[1] * numList[2];
                        }
                        else if (oper[0] == '*' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] * numList[1] / numList[2];
                        }
                        else if (oper[0] == '/' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] / numList[1] + numList[2];
                        }
                        else if (oper[0] == '/' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] / numList[1] - numList[2];
                        }
                        else if (oper[0] == '/' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] / numList[1] * numList[2];
                        }
                        else if (oper[0] == '/' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] / numList[1] / numList[2];
                        }
                    }




                }
                else if (mainLen == 4)
                {
                    if (bracketPosition.Count > 0)
                    {
                        foreach (var b in bracketPosition)
                        {
                            if (b == 0)
                            {
                                front = true;
                                middle = false;
                                back = false;
                                break;
                            }
                            else if (b == l - 1)
                            {
                                back = true;
                                middle = false;
                                front = false;
                                break;
                            }
                            else
                            {
                                back = false;
                                middle = true;
                                front = false;
                                break;
                            }
                        }

                        if (front == true)
                        {
                            if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] + numList[1]) + numList[2] + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] + numList[1]) + numList[2] - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] + numList[1]) - numList[2] - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] + numList[1]) * numList[2] - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] + numList[1]) * numList[2] * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] + numList[1]) * numList[2] / numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] + numList[1]) / numList[2] / numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] + numList[1]) / numList[2] + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] + numList[1]) / numList[2] - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] + numList[1]) / numList[2] + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] + numList[1]) / numList[2] - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] + numList[1]) / numList[2] * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] + numList[1]) / numList[2] - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] + numList[1]) / numList[2] * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] + numList[1]) * numList[2] + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] + numList[1]) - numList[2] * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] + numList[1]) / numList[2] - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] + numList[1]) / numList[2] * numList[3];
                            }

                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] + numList[1]) * numList[2] + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] + numList[1]) - numList[2] * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] + numList[1]) - numList[2] / numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] + numList[1]) - numList[2] / numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] + numList[1]) - numList[2] + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] + numList[1]) + numList[2] * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] + numList[1]) + numList[2] / numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] - numList[1]) - numList[2] - numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] - numList[1]) - numList[2] + numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] - numList[1]) + numList[2] + numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] - numList[1]) * numList[2] + numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] - numList[1]) * numList[2] * numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] - numList[1]) * numList[2] / numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] - numList[1]) / numList[2] / numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] - numList[1]) / numList[2] - numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] - numList[1]) / numList[2] + numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] - numList[1]) / numList[2] + numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] - numList[1]) / numList[2] * numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] - numList[1]) * numList[2] / numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] - numList[1]) + numList[2] * numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] - numList[1]) + numList[2] / numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] - numList[1]) + numList[2] - numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] - numList[1]) - numList[2] * numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] - numList[1]) - numList[2] / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] * numList[1]) * numList[2] * numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] * numList[1]) * numList[2] / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] * numList[1]) / numList[2] / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] * numList[1]) + numList[2] / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] * numList[1]) + numList[2] + numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] * numList[1]) + numList[2] - numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] * numList[1]) - numList[2] - numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] * numList[1]) - numList[2] * numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] * numList[1]) - numList[2] / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] * numList[1]) - numList[2] / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] * numList[1]) - numList[2] + numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] * numList[1]) - numList[2] / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] * numList[1]) - numList[2] + numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] * numList[1]) + numList[2] * numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] * numList[1]) / numList[2] + numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] * numList[1]) - numList[2] / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] * numList[1]) - numList[2] + numList[3];
                            }

                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] * numList[1]) + numList[2] * numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] * numList[1]) / numList[2] + numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] * numList[1]) / numList[2] - numList[3];
                            }

                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] * numList[1]) / numList[2] * numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] * numList[1]) * numList[2] / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] + numList[1]) + numList[2] * numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] / numList[1]) / numList[2] / numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] / numList[1]) / numList[2] * numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] / numList[1]) * numList[2] * numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] / numList[1]) + numList[2] * numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] / numList[1]) + numList[2] + numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] / numList[1]) + numList[2] - numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] / numList[1]) - numList[2] - numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] / numList[1]) - numList[2] / numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] / numList[1]) - numList[2] * numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = (numList[0] / numList[1]) - numList[2] * numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] / numList[1]) - numList[2] + numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] / numList[1]) + numList[2] - numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] / numList[1]) * numList[2] + numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] / numList[1]) * numList[2] - numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = (numList[0] / numList[1]) * numList[2] / numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = (numList[0] / numList[1]) / numList[2] + numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = (numList[0] / numList[1]) / numList[2] - numList[3];
                            }

                        }
                        else if (middle == true)
                        {
                            if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + (numList[1] + numList[2]) + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + (numList[1] + numList[2]) - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + (numList[1] - numList[2]) - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + (numList[1] * numList[2]) - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + (numList[1] * numList[2]) * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + (numList[1] * numList[2]) / numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + (numList[1] / numList[2]) / numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + (numList[1] / numList[2]) + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + (numList[1] / numList[2]) - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + (numList[1] / numList[2]) + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + (numList[1] / numList[2]) - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + (numList[1] / numList[2]) * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + (numList[1] / numList[2]) - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + (numList[1] / numList[2]) * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + (numList[1] * numList[2]) + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + (numList[1] - numList[2]) * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + (numList[1] / numList[2]) - numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + (numList[1] / numList[2]) * numList[3];
                            }

                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + (numList[1] * numList[2]) + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + (numList[1] - numList[2]) * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + (numList[1] - numList[2]) / numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + (numList[1] - numList[2]) / numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + (numList[1] - numList[2]) + numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + (numList[1] + numList[2]) * numList[3];
                            }
                            else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + (numList[1] + numList[2]) / numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] - (numList[1] - numList[2]) - numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - (numList[1] - numList[2]) + numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - (numList[1] + numList[2]) + numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - (numList[1] * numList[2]) + numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] - (numList[1] * numList[2]) * numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - (numList[1] * numList[2]) / numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - (numList[1] / numList[2]) / numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] - (numList[1] / numList[2]) - numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - (numList[1] / numList[2]) + numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - (numList[1] / numList[2]) + numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] - (numList[1] / numList[2]) * numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - (numList[1] * numList[2]) / numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] - (numList[1] + numList[2]) * numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - (numList[1] + numList[2]) / numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] - (numList[1] + numList[2]) - numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] - (numList[1] - numList[2]) * numList[3];
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - (numList[1] - numList[2]) / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * (numList[1] * numList[2]) * numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * (numList[1] * numList[2]) / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * (numList[1] / numList[2]) / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * (numList[1] + numList[2]) / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * (numList[1] + numList[2]) + numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] * (numList[1] + numList[2]) - numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] * (numList[1] - numList[2]) - numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * (numList[1] - numList[2]) * numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * (numList[1] - numList[2]) / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * (numList[1] - numList[2]) / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * (numList[1] - numList[2]) + numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * (numList[1] - numList[2]) / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * (numList[1] - numList[2]) + numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * (numList[1] + numList[2]) * numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * (numList[1] / numList[2]) + numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * (numList[1] - numList[2]) / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * (numList[1] - numList[2]) + numList[3];
                            }

                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * (numList[1] + numList[2]) * numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * (numList[1] / numList[2]) + numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] * (numList[1] / numList[2]) - numList[3];
                            }

                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * (numList[1] / numList[2]) * numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * (numList[1] * numList[2]) / numList[3];
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] * (numList[1] * numList[2]) - numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] / (numList[1] / numList[2]) / numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] / (numList[1] / numList[2]) * numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] / (numList[1] * numList[2]) * numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] / (numList[1] + numList[2]) * numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] / (numList[1] + numList[2]) + numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / (numList[1] + numList[2]) - numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / (numList[1] - numList[2]) - numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] / (numList[1] - numList[2]) / numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] / (numList[1] - numList[2]) * numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] / (numList[1] - numList[2]) + numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / (numList[1] + numList[2]) - numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] / (numList[1] * numList[2]) + numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / (numList[1] * numList[2]) - numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] / (numList[1] * numList[2]) / numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] / (numList[1] / numList[2]) + numList[3];
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / (numList[1] / numList[2]) - numList[3];
                            }
                        }
                        else if (back == true)
                        {
                            if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + numList[1] + (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + numList[1] + (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + numList[1] - (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + numList[1] * (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + numList[1] * (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + numList[1] * (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + numList[1] / (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + numList[1] / (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + numList[1] / (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + numList[1] / (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + numList[1] / (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + numList[1] / (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + numList[1] / (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + numList[1] / (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + numList[1] * (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + numList[1] - (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] + numList[1] / (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + numList[1] / (numList[2] * numList[3]);
                            }

                            else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + numList[1] * (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + numList[1] - (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + numList[1] - (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + numList[1] - (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] + numList[1] - (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] + numList[1] + (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] + numList[1] + (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] - numList[1] - (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - numList[1] - (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - numList[1] + (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - numList[1] * (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] - numList[1] * (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - numList[1] * (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - numList[1] / (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] - numList[1] / (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - numList[1] / (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] - numList[1] / (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] - numList[1] / (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - numList[1] * (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] - numList[1] + (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - numList[1] + (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] - numList[1] + (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] - numList[1] - (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] - numList[1] - (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * numList[1] * (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * numList[1] * (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * numList[1] / (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * numList[1] + (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * numList[1] + (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] * numList[1] + (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] * numList[1] - (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * numList[1] - (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * numList[1] - (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * numList[1] - (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * numList[1] - (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * numList[1] - (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * numList[1] - (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * numList[1] + (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * numList[1] / (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * numList[1] - (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * numList[1] - (numList[2] + numList[3]);
                            }

                            else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * numList[1] + (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] * numList[1] / (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] * numList[1] / (numList[2] - numList[3]);
                            }

                            else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] * numList[1] / (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] * numList[1] * (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] * numList[1] * (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] / numList[1] / (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] / numList[1] / (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] / numList[1] * (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] / numList[1] + (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] / numList[1] + (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / numList[1] + (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / numList[1] - (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] / numList[1] - (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                            {
                                total = numList[0] / numList[1] - (numList[2] * numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] / numList[1] - (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / numList[1] + (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] / numList[1] * (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / numList[1] * (numList[2] - numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                            {
                                total = numList[0] / numList[1] * (numList[2] / numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                            {
                                total = numList[0] / numList[1] / (numList[2] + numList[3]);
                            }
                            else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                            {
                                total = numList[0] / numList[1] / (numList[2] - numList[3]);
                            }
                        }
                    }
                    else
                    {
                        if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] + numList[1] + numList[2] + numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] + numList[1] + numList[2] - numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] + numList[1] - numList[2] - numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] + numList[1] * numList[2] - numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] + numList[1] * numList[2] * numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] + numList[1] * numList[2] / numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] + numList[1] / numList[2] / numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] + numList[1] / numList[2] + numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] + numList[1] / numList[2] - numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] + numList[1] / numList[2] + numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] + numList[1] / numList[2] - numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] + numList[1] / numList[2] * numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] + numList[1] / numList[2] - numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] + numList[1] / numList[2] * numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] + numList[1] * numList[2] + numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] + numList[1] - numList[2] * numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] + numList[1] / numList[2] - numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] + numList[1] / numList[2] * numList[3];
                        }

                        else if (oper[0] == '+' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] + numList[1] * numList[2] + numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] + numList[1] - numList[2] * numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] + numList[1] - numList[2] / numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] + numList[1] - numList[2] / numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] + numList[1] - numList[2] + numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] + numList[1] + numList[2] * numList[3];
                        }
                        else if (oper[0] == '+' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] + numList[1] + numList[2] / numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] - numList[1] - numList[2] - numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] - numList[1] - numList[2] + numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] - numList[1] + numList[2] + numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] - numList[1] * numList[2] + numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] - numList[1] * numList[2] * numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] - numList[1] * numList[2] / numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] - numList[1] / numList[2] / numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] - numList[1] / numList[2] - numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] - numList[1] / numList[2] + numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] - numList[1] / numList[2] + numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] - numList[1] / numList[2] * numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] - numList[1] * numList[2] / numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] - numList[1] + numList[2] * numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] - numList[1] + numList[2] / numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] - numList[1] + numList[2] - numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] - numList[1] - numList[2] * numList[3];
                        }
                        else if (oper[0] == '-' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] - numList[1] - numList[2] / numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] * numList[1] * numList[2] * numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] * numList[1] * numList[2] / numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] * numList[1] / numList[2] / numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] * numList[1] + numList[2] / numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] * numList[1] + numList[2] + numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] * numList[1] + numList[2] - numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] * numList[1] - numList[2] - numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] * numList[1] - numList[2] * numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] * numList[1] - numList[2] / numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] * numList[1] - numList[2] / numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] * numList[1] - numList[2] + numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] * numList[1] - numList[2] / numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] * numList[1] - numList[2] + numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] * numList[1] + numList[2] * numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] * numList[1] / numList[2] + numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] * numList[1] - numList[2] / numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] * numList[1] - numList[2] + numList[3];
                        }

                        else if (oper[0] == '*' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] * numList[1] + numList[2] * numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] * numList[1] / numList[2] + numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] * numList[1] / numList[2] - numList[3];
                        }

                        else if (oper[0] == '*' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] * numList[1] / numList[2] * numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] * numList[1] * numList[2] / numList[3];
                        }
                        else if (oper[0] == '*' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] * numList[1] * numList[2] - numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] / numList[1] / numList[2] / numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] / numList[1] / numList[2] * numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] / numList[1] * numList[2] * numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] / numList[1] + numList[2] * numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] / numList[1] + numList[2] + numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] / numList[1] + numList[2] - numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] / numList[1] - numList[2] - numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] / numList[1] - numList[2] / numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '*')
                        {
                            total = numList[0] / numList[1] - (numList[2] * numList[3]);
                        }
                        else if (oper[0] == '/' && oper[1] == '-' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] / numList[1] - numList[2] + numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '+' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] / numList[1] + numList[2] - numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] / numList[1] * numList[2] + numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] / numList[1] * numList[2] - numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '*' && oper[oper.Count - 1] == '/')
                        {
                            total = numList[0] / numList[1] * numList[2] / numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '+')
                        {
                            total = numList[0] / numList[1] / numList[2] + numList[3];
                        }
                        else if (oper[0] == '/' && oper[1] == '/' && oper[oper.Count - 1] == '-')
                        {
                            total = numList[0] / numList[1] / numList[2] - numList[3];
                        }
                    }
                }
                else if (mainLen > 4)
                {
                    if (j1 > 0 && j2 > 0 && j3 > 0)
                    {
                        var str1 = sum.Substring(j1 + 1, (j2 - j1) + 1);
                        var j4 = str1.IndexOf("(");
                        var j5 = str1.IndexOf(")");
                        var str2 = str1.Substring(j4 + 1, (j5 - (j4 + 1)));
                        var str3 = str1.Substring(0, str1.IndexOf("("));
                        var str4 = sum.Substring(0, j1);
                        var num = "";
                        var num2 = "";
                        var num3 = "";
                        List<char> oper2 = new List<char>();
                        List<char> oper3 = new List<char>();
                        List<char> oper4 = new List<char>();
                        List<double> n2 = new List<double>();
                        List<double> n3 = new List<double>();
                        List<double> n4 = new List<double>();
                        int m = 0;
                        int r = 0;
                        int z = 0;
                        double d3 = 0;
                        double d4 = 0;
                        double d5 = 0;

                        foreach (var s2 in str2)
                        {
                            if (Char.IsDigit(s2))
                            {
                                num = num + s2;
                            }
                            else if (s2 == '+' || s2 == '-' || s2 == '*' || s2 == '/')
                            {
                                oper2.Add(s2);
                            }
                            else if (s2 == ' ')
                            {
                                if (num != "")
                                {
                                    n2.Add(Convert.ToDouble(num));
                                    num = "";
                                }
                            }

                            if (m == str2.Length - 1)
                            {
                                if (num != "")
                                {
                                    n2.Add(Convert.ToDouble(num));
                                    num = "";
                                }
                            }

                            m++;
                        }

                        if (n2.Count == 2 && oper2.Count == 1)
                        {
                            if (oper2[0] == '+')
                            {
                                d3 = n2[0] + n2[1];
                            }
                            else if (oper2[0] == '-')
                            {
                                d3 = n2[0] - n2[1];
                            }
                            else if (oper2[0] == '*')
                            {
                                d3 = n2[0] * n2[1];
                            }
                            else if (oper2[0] == '/')
                            {
                                d3 = n2[0] / n2[1];
                            }
                        }

                        foreach (var s3 in str3)
                        {
                            if (Char.IsDigit(s3))
                            {
                                num2 = num2 + s3;
                            }
                            else if (s3 == '+' || s3 == '-' || s3 == '*' || s3 == '/')
                            {
                                oper3.Add(s3);
                            }
                            else if (s3 == ' ')
                            {
                                if (num2 != "")
                                {
                                    n3.Add(Convert.ToDouble(num2));
                                    num2 = "";
                                }
                            }

                            if (r == str3.Length - 1)
                            {
                                if (num2 != "")
                                {
                                    n3.Add(Convert.ToDouble(num2));
                                    num2 = "";
                                }
                            }

                            r++;
                        }

                        if (n3.Count == 2 && oper3.Count == 2)
                        {
                            if (oper3[1] == '+')
                            {
                                d4 = n3[1] + d3;
                            }
                            else if (oper3[1] == '-')
                            {
                                d4 = n3[1] - d3;
                            }
                            else if (oper3[1] == '*')
                            {
                                d4 = n3[1] * d3;
                            }
                            else if (oper3[1] == '/')
                            {
                                d4 = n3[1] / d3;
                            }

                            if (oper3[0] == '+')
                            {
                                d5 = n3[0] + d4;
                            }
                            else if (oper3[0] == '-')
                            {
                                d5 = n3[0] - d4;
                            }
                            else if (oper3[0] == '*')
                            {
                                d5 = n3[0] * d4;
                            }
                            else if (oper3[0] == '/')
                            {
                                d5 = n3[0] / d4;
                            }
                        }

                        foreach (var s4 in str4)
                        {
                            if (Char.IsDigit(s4))
                            {
                                num3 = num3 + s4;
                            }
                            else if (s4 == '+' || s4 == '-' || s4 == '*' || s4 == '/')
                            {
                                oper4.Add(s4);
                            }
                            else if (s4 == ' ')
                            {
                                if (num3 != "")
                                {
                                    n4.Add(Convert.ToDouble(num3));
                                    num3 = "";
                                }
                            }



                            if (z == str4.Length - 1)
                            {
                                if (num3 != "")
                                {
                                    n4.Add(Convert.ToDouble(num3));
                                    num3 = "";
                                }
                            }

                            z++;
                        }

                        if (n4.Count == 1 && oper4.Count == 1)
                        {
                            if (oper4[0] == '+')
                            {
                                total = n4[0] + d5;
                            }
                            else if (oper4[0] == '-')
                            {
                                total = n4[0] - d5;
                            }
                            else if (oper4[0] == '*')
                            {
                                total = n4[0] * d5;
                            }
                            else if (oper4[0] == '/')
                            {
                                total = n4[0] / d5;
                            }
                        }
                    }
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
