using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.DataManagement.Server.Extensibility.Numbering;

namespace CustomNumberingProvider
{
    public class CustomNumberingProvider : INumberProvider
    {
        private static string m_initializationParmPrefix = "";

        public IList<NumberProviderResponse> GenerateNumbers(NumberProviderRequest request, int num = 1)
        {
            // We can generate our number responses here:
            List<NumberProviderResponse> responses = new List<NumberProviderResponse>();

            // If we can't generate a number, we can return a general failure code:
            if (num <= 0 || !this.IsRequestSupported(request))
            {
                responses.Add(new NumberProviderResponse(ErrorCodes.Failure, ""));
                return responses;
            }

            while (num-- > 0)
            {
                // This is where we create the response with our newly generated number
                //                                                           ---------Below is the newly generated number----------
                responses.Add(new NumberProviderResponse(ErrorCodes.Success, m_initializationParmPrefix + Guid.NewGuid().ToString()));
            }

            return responses;
        }

        public string GetDisplayName()
        {
            // We can set what name the client sees here:
            return "Custom Numbering Provider";
        }

        public void Init(object[] parameters)
        {
            // If our server-side web.config defines an 
            // initializationParm node, we can cast and
            // assign it here:
            if (parameters.Count() == 0)
                return;

            m_initializationParmPrefix = parameters.First().ToString();
        }

        // Note: IsRequestSupported is not called from the server, 
        // it is internal only as of this time
        public bool IsRequestSupported(NumberProviderRequest request)
        {
            // We can restrict what kind of requests are supported by our number provider here:
            bool HasRestrictedField = request.Fields.Any(field => field.Type == FieldType.PredefinedList);

            return !HasRestrictedField;
        }
    }
}
