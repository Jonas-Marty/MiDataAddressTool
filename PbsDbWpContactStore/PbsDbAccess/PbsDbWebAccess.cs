using PbsDbAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PbsDbAccess
{
    /// <summary>
    /// A class containing methods to access the data from the national PBS database.
    /// Use the static method <see cref="CreateInstanceAsyncServiceUser"/> to create an instance of this
    /// class asynchronusely.
    /// </summary>
    public class PbsDbWebAccess
    {
        /// <summary>
        /// The information used for authentification against the webserver.
        /// </summary>
        private readonly LoggedinUserInformation _loggedinUserInformation;

        /// <summary>
        /// The client used for all http requests.
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Creates a new instance of the <see cref="PbsDbWebAccess"/> class using the given
        /// <see cref="LoggedinUserInformation"/> instance. The instance should only contain valid
        /// credentials. They are not checked again.
        /// </summary>
        /// <param name="loggedinUserInformation">The information of the logged in user.</param>
        private PbsDbWebAccess(LoggedinUserInformation loggedinUserInformation)
        {
            _loggedinUserInformation = loggedinUserInformation;
            _client = CreateHttpClient();
        }

        /// <summary>
        /// Recieves the first following subgroups of the layergroup including the layer group from the logged in user.
        /// </summary>
        /// <returns>First following subgroups.</returns>
        public Task<IEnumerable<Group>> RecieveAllGroupsFromLayerGroupAsync()
        {
            return RecieveAllGroupsFromLayerGroupAsync(false);
        }

        /// <summary>
        /// Recieves all subgroups of the layergroup including the layer group from the logged in user.
        /// </summary>
        /// <returns>All subgroups.</returns>
        public Task<IEnumerable<Group>> RecieveAllGroupsFromLayerGroupRecursiveAsync()
        {
            return RecieveAllGroupsFromLayerGroupAsync(true);
        }
        
        /// <summary>
        /// Recieves all people of the group with the given id. Only persons will be returned, 
        /// to which the logged in user also have access to view on the web page.
        /// </summary>
        /// <param name="groupId">The id of the group.</param>
        /// <returns>People ofh the group.</returns>
        public async Task<IEnumerable<Person>> RecievePersonsOfGroupAsync(string groupId)
        {
            string jsonResponse = await RecieveJsonStringContentAsync(string.Format(UrlConstants.PersonsOfGroupUrlFormatString, groupId));

            return JsonParser.ParsePeopleOfGroup(jsonResponse);
        }

        /// <summary>
        /// Recieves the next higher layergroup of the primary group from the logged in user.
        /// If the primary group is allready a layer group, this group will be returned.
        /// </summary>
        /// <returns>Layergroup.</returns>
        public async Task<Group> RecieveLayerGroupOfLoggedInUser()
        {
            Group primaryGroup = await RecievePrimaryGroupFromLoggedInUserAsync();
            return await RecieveLayerGroupFromGroup(primaryGroup);
        }

        /// <summary>
        /// Creates an instance of the <see cref="PbsDbWebAccess"/> class. The given credentails are
        /// evaluated instantly so the method neds a lot of time. If the credentials are invalid, 
        /// an <see cref="InvalidLoginInformationException"/> will be thrown.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <exception cref="InvalidLoginInformationException">The exception thrown when the credentials are invalid.</exception>
        /// <returns>An instance of the <see cref="PbsDbWebAccess"/> class.</returns>
        public static async Task<PbsDbWebAccess> CreateInstanceAsyncUser(string email, string password)
        {
            var client = CreateHttpClient();

            var formData = new Dictionary<string, string> { { UrlConstants.EmailFormDataString, email }, { UrlConstants.PasswortFormDataString, password } };
            FormUrlEncodedContent requestContent = new FormUrlEncodedContent(formData);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, UrlConstants.ReadTokenUrl);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(UrlConstants.JsonMimeType));
            requestMessage.Content = requestContent;

            HttpResponseMessage response = await client.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                HandleStatusCodeErrors(response);
            }

            string responseContent = await response.Content.ReadAsStringAsync();

            LoggedinUserInformation loggedinUserInformation = JsonParser.ParseLoggedinUserInformation(responseContent);

            return new PbsDbWebAccess(loggedinUserInformation);
        }

        public static async Task<PbsDbWebAccess> CreateInstanceAsyncServiceUser(string apiToken, string primaryGroupId)
        {
            var access = new PbsDbWebAccess(new LoggedinUserInformation { ApiToken = apiToken, PrimaryGroupId = primaryGroupId });

            await access.RecieveGroupByIdAsync(primaryGroupId);

            return access;
        }


        /// <summary>
        /// Recieves the Layergroup of the given group. If the group is allready a layer group,
        /// the method returns the given group.
        /// </summary>
        /// <param name="group">The group for which the layergroup is searched.</param>
        /// <returns>Layergroup of the given group.</returns>
        private async Task<Group> RecieveLayerGroupFromGroup(Group group)
        {
            if (group.IsLayerGroup)
            {
                return group;
            }
            return await RecieveGroupByIdAsync(group.LayerGroupId);
        }

        /// <summary>
        /// Recieves all subgroups of a given group. 
        /// </summary>
        /// <param name="group">The group of which the subgroups should be returned.</param>
        /// <param name="recursive">Determines if the subgroups of the subgroups should be included recursivly.</param>
        /// <returns>Set of subgroups.</returns>
        private async Task<List<Group>> RecieveAllSubGroupsFromGroupAsync(Group group, bool recursive = false)
        {
            List<Group> groups = new List<Group>();
            if (group.ChildGroupIds != null)
            {
                foreach (string childGroupId in group.ChildGroupIds)
                {
                    var childGroup = await RecieveGroupByIdAsync(childGroupId);
                    groups.Add(childGroup);
                    if (recursive)
                    {
                        var subGroups = await RecieveAllSubGroupsFromGroupAsync(childGroup, true);
                        groups.AddRange(subGroups);
                    }
                }
            }
            return groups;
        }

        /// <summary>
        /// Returns the primary group of the loggedin user.
        /// </summary>
        /// <returns>Primary group of the logged in user.</returns>
        private async Task<Group> RecievePrimaryGroupFromLoggedInUserAsync()
        {
            return await RecieveGroupByIdAsync(_loggedinUserInformation.PrimaryGroupId);
        }

        /// <summary>
        /// Recieves the all groups from the layergroup of the loggedin user. The primary group of the user
        /// is used for determining the next layergroup. The parameter <paramref name="recursive"/> determines
        /// only the subgroups of the layergroup should be returned or if all subgroubs of all groubs should be
        /// returned recursivly. The Layergroup itself is included.
        /// </summary>
        /// <param name="recursive">Determines if the groups should be returned recursivly or not.</param>
        /// <returns>All subgroups of the layergroup.</returns>
        private async Task<IEnumerable<Group>> RecieveAllGroupsFromLayerGroupAsync(bool recursive)
        {
            var layerGroup = await RecieveLayerGroupOfLoggedInUser();

            var subGroups = await RecieveAllSubGroupsFromGroupAsync(layerGroup, recursive);

            subGroups.Add(layerGroup);

            return subGroups;
        }

        /// <summary>
        /// Recieves a group according to its id from the web server.
        /// </summary>
        /// <param name="groupId">The id of the group.</param>
        /// <returns>The <see cref="Group"/> instance.</returns>
        private async Task<Group> RecieveGroupByIdAsync(string groupId)
        {
            string jsonResponse = await RecieveJsonStringContentAsync(string.Format(UrlConstants.GroupDetailsUrlFormatString, groupId));

            return JsonParser.ParseGroup(jsonResponse);
        }

        /// <summary>
        /// Generalized method to recieve any json string from the given url.
        /// </summary>
        /// <param name="uri">The uri part to send the request to.</param>
        /// <returns>Json string.</returns>
        private async Task<string> RecieveJsonStringContentAsync(string uri)
        {
            var requestMessage = CreateGetRequestMessage(uri);
            var response = await _client.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                HandleStatusCodeErrors(response);
            }

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Creates a request message to the given uri with the HTTP GET method.
        /// </summary>
        /// <param name="uri">The uri to request.</param>
        /// <returns>The created <see cref="HttpRequestMessage"/>.</returns>
        private HttpRequestMessage CreateGetRequestMessage(string uri)
        {
            return CreateRequestMessage(uri, HttpMethod.Get);
        }

        /// <summary>
        /// Creats a request message to the given uri with the given method.
        /// </summary>
        /// <param name="uri">The uri to request.</param>
        /// <param name="method">The method to use.</param>
        /// <returns>The created <see cref="HttpRequestMessage"/>.</returns>
        private HttpRequestMessage CreateRequestMessage(string uri, HttpMethod method)
        {
            HttpRequestMessage message = new HttpRequestMessage(method, uri);
            if (!string.IsNullOrWhiteSpace(_loggedinUserInformation.Email))
            {
                message.Headers.Add("X-User-Email", _loggedinUserInformation.Email);
            }
            if (!string.IsNullOrWhiteSpace(_loggedinUserInformation.UserToken))
            {
                message.Headers.Add("X-User-Token", _loggedinUserInformation.UserToken);
            }
            if (!string.IsNullOrWhiteSpace(_loggedinUserInformation.ApiToken))
            {
                message.Headers.Add("X-Token", _loggedinUserInformation.ApiToken);
            }
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(UrlConstants.JsonMimeType));
            return message;
        }

        /// <summary>
        /// Handles status code errors. This method assumes that a error is present.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> to handle</param>
        private static void HandleStatusCodeErrors(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new InvalidLoginInformationException();
            }

            throw new Exception(FormatHttpErrorMessage(response));
        }

        /// <summary>
        /// Formats an <see cref="HttpResponseMessage"/> for console output.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> to format.</param>
        /// <returns>The formated string.</returns>
        private static string FormatHttpErrorMessage(HttpResponseMessage response)
        {
            return $"{response.StatusCode} - {response.ReasonPhrase}\n\nResponse:\n{response.Content.ReadAsStringAsync().Result}";
        }

        /// <summary>
        /// Creates an Uri with the given path and parameters. <para>urlWithoutParameters</para> must not
        /// have any parameters in it!
        /// </summary>
        /// <param name="urlWithoutParameters">An url (relativ or absolut) wihtout any parameters.</param>
        /// <param name="parameterValueCollection">A dictionay containing the parameter name as the key and its value as the values.</param>
        /// <returns>The uri with the given path and parameters.</returns>
        private static Uri CreateUriWithParameters(string urlWithoutParameters, Dictionary<string, string> parameterValueCollection)
        {
            var parameterValueProjection = parameterValueCollection
                .Select(keyValuePair => $"{keyValuePair.Key}={keyValuePair.Value}");
            string queryString = "?" + string.Join("&", parameterValueProjection);
            return new Uri(urlWithoutParameters + queryString);
        }

        /// <summary>
        /// Creates the correctly preconfigured <see cref="HttpClient"/> with the BaseAddress property allready set. Use allways this method.
        /// </summary>
        /// <returns>The correctly preconfigured <see cref="HttpClient"/> to comunicate with the PBS DB.</returns>
        private static HttpClient CreateHttpClient()
        {
            return new HttpClient { BaseAddress = new Uri(UrlConstants.BaseUrl) };
        }
    }

}
