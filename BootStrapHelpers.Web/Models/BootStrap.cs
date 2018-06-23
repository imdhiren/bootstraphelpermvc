using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrapHelpers.Web.Models
{
    public class DateViewModel
    {
        public DateViewModel()
        {
            Date1 = DateTime.Today;
        }
        public DateTime Date1 { get; set; }

        public DateTime? Date2 { get; set; }
    }
    public class LoginViewModels
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class MainViewModel
    {
        public DateViewModel DateViewModel { get; set; }
        public LoginViewModels LoginViewModels { get; set; }
    }
}