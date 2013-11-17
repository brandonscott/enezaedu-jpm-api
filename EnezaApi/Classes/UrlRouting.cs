using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnezaApi.Classes
{
    public static class UrlRouting
    {
        public static  Dictionary<string, Object> SplitParams(string parameters)
        {
            string[] ps = null;
            Dictionary<string, Object> paramObj = new  Dictionary<string, Object>();

            if (parameters.Contains("/"))
            {
                ps = parameters.Split('/');
            }
            else
            {
                ps = new String[]{parameters};
            }

            foreach (string p in ps)
            {
                if (p.Contains(':'))
                {
                    ps = p.Split(':');
                    if (ps.Count() == 2)
                    {
                        int convNum;
                        if (Int32.TryParse(ps[1], out convNum))
                        {
                            paramObj.Add(ps[0].ToString(), convNum);
                        }
                        else
                        {
                            paramObj.Add(ps[0].ToString(), ps[1].ToString());
                        }
                    }
                }
                else if (p == "student" || p == "teacher")
                {
                    paramObj.Add("type", p);
                }
            }

            return paramObj;
        }
    }
}