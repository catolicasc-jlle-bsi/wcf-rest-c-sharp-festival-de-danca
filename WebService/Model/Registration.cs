using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Model
{
    public class Registration
    {
        public Guid AppToken { get; set; }

        public Registration()
        {
            this.AppToken = Guid.NewGuid();
        }
    }
}