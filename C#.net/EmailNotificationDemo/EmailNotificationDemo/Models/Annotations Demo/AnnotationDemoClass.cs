using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailNotificationDemo.Models
{
    public class AnnotationDemoClass
    {
        [DemoAnnotation]
        public string InputString { get; set; }
    }
}