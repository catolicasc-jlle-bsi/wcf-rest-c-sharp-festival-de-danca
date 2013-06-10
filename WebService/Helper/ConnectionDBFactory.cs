using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Db4objects.Db4o;

namespace WebService.Helper
{
    public class ConnectionDBFactory
    {
        public static readonly string PATH =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "votopopular_server.yap");

        public IEmbeddedObjectContainer Create()
        {
            return Db4oEmbedded.OpenFile(PATH);
        }
    }
}
