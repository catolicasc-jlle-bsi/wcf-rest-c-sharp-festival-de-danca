using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using System.Net;
using WebService.Helper;

namespace WebService.Helper
{
    public sealed class Session
    {
        private static readonly Session instance;
        public IObjectContainer Database { get; set; }
        public ConnectionInternetFactory Internet { get; set; }

        public static Session Current
        {
            get
            {
                return instance;
            }
        }

        static Session()
        {
            instance = new Session();
            instance.Database = new ConnectionDBFactory().Create();
            instance.Internet = new ConnectionInternetFactory().Create();
        }

        private Session() { }
    }
}
