using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelFirst.ViewModels
{
    public class MessageViewModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string URL { get; set; }
        public string LinkText { get; set; }
    }
}