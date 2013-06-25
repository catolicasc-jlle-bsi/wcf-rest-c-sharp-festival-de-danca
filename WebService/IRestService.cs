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
        string Seeds();

        [WebInvoke(UriTemplate = "/GetConnection",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetConnection();

        [WebInvoke(UriTemplate = "/AllVotes",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AllVotes();

        [WebInvoke(UriTemplate = "/CurrentApresentation?date={interval}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string CurrentApresentation(string interval);

        [WebInvoke(UriTemplate = "/UploadVote/{vote}",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string UploadVote(string vote);

        //[WebInvoke(UriTemplate = "/HistoryPresentations?date={date}&time={time}",
        [WebInvoke(UriTemplate = "/HistoryPresentations?date={interval}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string HistoryPresentations(string interval);
    }
}
