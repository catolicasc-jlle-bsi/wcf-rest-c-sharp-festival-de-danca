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

        public void Seeds()
        {
            new Seeds();
        }

        /*
        public string Registration()
        {
            Registration registration = null;
            //Guid token = Guid.Empty;
            try
            {
                registration = new Registration();
                new RegistrationController().Save(registration);
                //token = Guid.NewGuid();
                //new RegistrationController().Save(token);
            }
            catch (Exception e)
            {
                
            }
            return JsonConvert.SerializeObject(registration);
        }*/

        public string AllVotes()
        {
            return JsonConvert.SerializeObject(
                new VoteController().SelectAll<Vote>());
        }

        public string CurrentApresentation(string date)
        {
            return JsonConvert.SerializeObject(
                new ApresentationController().Select(DateTime.Now));
        }

        public string UploadVote(string vote)
        {
            JsonResponse response = new JsonResponse();
            var result = false;
            try
            {
                var voteConvert = JsonConvert.DeserializeObject<Vote>(vote);
                new VoteController().Save(voteConvert);
                response.Status = true;
                result = true;
            }
            catch (Exception) { }

            return JsonConvert.SerializeObject(result);
        }

        public string AllPresentations()
        {
            var d = JsonConvert.SerializeObject(
                new ApresentationController().SelectAll<Apresentation>(),
                new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.Default, FloatFormatHandling = FloatFormatHandling.String });

            var e = JsonConvert.SerializeObject(
                new ApresentationController().SelectAll<Apresentation>(),
                new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeHtml });

            var a = JsonConvert.SerializeObject(
                new ApresentationController().SelectAll<Apresentation>(),
                new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii });

            return JsonConvert.SerializeObject(
                new ApresentationController().SelectAll<Apresentation>());
        }



        public string GetTest()
        {
            return "OK";
        }
    }
}
