using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;

namespace WebService.Helper
{
    public class ConnectionInternetFactory : WebClient
    {
        public ConnectionInternetFactory Create()
        {
            GerenciadorProxy gerenciadorProxy = null;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Endereco"]) &&
                !string.IsNullOrEmpty(ConfigurationManager.AppSettings["Porta"]))
            {
                gerenciadorProxy = new GerenciadorProxy(
                    ConfigurationManager.AppSettings["Endereco"],
                    ConfigurationManager.AppSettings["Porta"]);
            }

            if (gerenciadorProxy != null)
            {
                Proxy = new WebProxy(string.Format("http://{0}:{1}", gerenciadorProxy.Endereco, gerenciadorProxy.Porta));
                Proxy.Credentials = CredentialCache.DefaultCredentials;
            }
            return this;
        }

        public string Down(string url)
        {
            try
            {
                using (StreamReader reader = new StreamReader(this.OpenRead(url)))
                {
                    return WebUtility.HtmlDecode(reader.ReadToEnd());
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}

