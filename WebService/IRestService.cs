using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace WebService
{
    [ServiceContract]
    public interface IRestService
    {
        [WebInvoke(UriTemplate = "/Seeds",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void Seeds();

        /*
        [WebInvoke(UriTemplate = "/Registration",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Registration();
        */

        [WebInvoke(UriTemplate = "/AllVotes",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AllVotes();

        [WebInvoke(UriTemplate = "/CurrentApresentation/{date}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string CurrentApresentation(string date);

        [WebInvoke(UriTemplate = "/UploadVote/{vote}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string UploadVote(string vote);

        [WebInvoke(UriTemplate = "/AllPresentations",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AllPresentations();
    }
}