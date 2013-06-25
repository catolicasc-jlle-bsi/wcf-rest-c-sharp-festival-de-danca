using BusinessObject.Voting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using WebService.Controller;
using WebService.Model;
using BusinessObject.Helper;
using WebService.Helper;

namespace WebService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class RestService : IRestService
    {
        
        private string GetError(string message)
        {
            return "Erro. Detalhes: " + message;
        }

        /// <summary>
        /// http://localhost:62425/RestService.svc/Seeds
        /// </summary>
        public string Seeds()
        {
            try
            {
                new Seeds();
                return "Seeds OK";
            }
            catch (Exception e)
            {
                return this.GetError(e.Message);
            }
        }

        /// <summary>
        /// http://localhost:62425/RestService.svc/AllVotes
        /// </summary>
        public string AllVotes()
        {
            try
            {
                return JsonConvert.SerializeObject(
                    new VoteController().SelectAll<Vote>());
            }
            catch (Exception e)
            {
                return this.GetError(e.Message);
            }
        }

        /// <summary>
        /// http://localhost:62425/RestService.svc/CurrentApresentation?date=24-06-2013%2021:32:00
        /// </summary>
        public string CurrentApresentation(string interval)
        {
            try
            {
                return JsonConvert.SerializeObject(
                    new ApresentationController().Current(
                        Convert.ToDateTime(interval)));
            }
            catch (Exception e)
            {
                return this.GetError(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UploadVote(string vote)
        {
            try
            {
                new VoteController().Save(
                    JsonConvert.DeserializeObject<Vote>(vote));
                return "Voto computado com sucesso!";
            }
            catch (Exception e)
            {
                return this.GetError(e.Message);
            }
        }

        /// <summary>
        /// http://localhost:62425/RestService.svc/HistoryPresentations?date=24-06-2013%2021:22:00
        /// </summary>
        public string HistoryPresentations(string interval)
        {
            try
            {
                return JsonConvert.SerializeObject(
                    new ApresentationController().History(
                        Convert.ToDateTime(interval)));
            }
            catch (Exception e)
            {
                return this.GetError(e.Message);
            }
        }

        /// <summary>
        /// http://localhost:62425/RestService.svc/GetConnection
        /// </summary>
        public string GetConnection()
        {
            return "true";
        }
    }
}

