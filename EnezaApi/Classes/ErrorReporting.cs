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

                // Users Error
                case 300:
                    description = "User is not a teacher or a student";
                    break;
                case 301:
                    description = "Could not delete User from Class list";
                    break;

                // Messages Error
                case 400:
                    description = "From or To Number not recognised";
                    break;
                case 401:
                    description = "Message Type not recognised";
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