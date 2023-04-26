using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmailNotificationDemo.Models
{
    public class DemoAnnotation:ValidationAttribute
    {
        public DemoAnnotation()
        {
            ErrorMessage = "String does not contain \"ing\"";
        }
        public override bool IsValid(object input)
        {
            string inputString = input as string;
            return inputString.Contains("ing");
        }
    }
}