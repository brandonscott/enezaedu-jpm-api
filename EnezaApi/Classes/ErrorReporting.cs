using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnezaApi.Classes
{
    public class ErrorReporting
    {
        public static CustomError GenerateCustomError(int code)
        {
            CustomError error = new CustomError();
            error.valid = false;
            error.code = code;
            error.description = LookupCode(code);

            return error;
        }

        public static String LookupCode(int code)
        {
            String description = "";

            switch(code)
            {
                // Parameter Errors
                case 100:
                    description = "something went wrong...";
                    break;

                // Auth Error
                case 200:
                    description = "Username and/or Password is Incorrect";
                    break;


                default:
                    description = "something went wrong...";
                    break;
            }

            return description;
        }
    }

    public class CustomError
    {
        public bool valid { get; set; }
        public int code { get; set; }
        public string description { get; set; }
    }
}