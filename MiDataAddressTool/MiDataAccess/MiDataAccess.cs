using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MiDataAccess.Models;

namespace MiDataAccess;

/// <summary>
/// A class containing methods to access the data from the national PBS database.
/// Use the static method <see cref="CreateInstanceAsync"/> to create an instance of this
/// class asynchronously.
/// </summary>
public class MiDataAccess
{
    /// <summary>
    /// The service token for accessing the api. See https://github.com/hitobito/hitobito/blob/master/doc/development/07_service_accounts.md
    /// </summary>
    private readonly string _serviceToken;

    /// <summary>
    /// The id of the top most group to access users.
    /// </summary>
    private readonly string _primaryGroupId;

    /// <summary>
    /// The client used for all http requests.
    /// </summary>
    private readonly HttpClient _client;

    /// <summary>
    /// Creates a new instance of the <see cref="MiDataAccess"/> class using the given
    /// serviceToken and primaryGroupId. The instance should only contain valid
    /// credentials. They are not checked again.
    /// </summary>
    /// <param name="serviceToken">The information of the logged in user.</param>
    /// <param name="primaryGroupId">The id of the primary group to retrieve people from.</param>
    private MiDataAccess(string serviceToken, string primaryGroupId)
    {
        _serviceToken = serviceToken;
        _primaryGroupId = primaryGroupId;
        _client = CreateHttpClient();
    }

    /// <summary>
    /// Receives the first following subgroups of the layergroup including the layer group from the logged in user.
    /// </summary>
    /// <returns>First following subgroups.</returns>
    public Task<IEnumerable<Group>> ReceiveAllGroupsFromLayerGroupAsync()
    {
        return ReceiveAllGroupsFromLayerGroupAsync(false);
    }

    /// <summary>
    /// Receives all subgroups of the layergroup including the layer group from the logged in user.
    /// </summary>
    /// <returns>All subgroups.</returns>
    public Task<IEnumerable<Group>> ReceiveAllGroupsFromLayerGroupRecursiveAsync()
    {
        return ReceiveAllGroupsFromLayerGroupAsync(true);
    }
        
    /// <summary>
    /// Receives all people of the group with the given id. Only persons will be returned, 
    /// to which the logged in user also have access to view on the web page.
    /// </summary>
    /// <param name="groupId">The id of the group.</param>
    /// <returns>People ofh the group.</returns>
    public async Task<IEnumerable<Person>> ReceivePersonsOfGroupAsync(string groupId)
    {
        string jsonResponse = await ReceiveJsonStringContentAsync(string.Format(UrlConstants.PersonsOfGroupUrlFormatString, groupId));

        return JsonParser.ParsePeopleOfGroup(jsonResponse);
    }

    /// <summary>
    /// Receives the next higher layergroup of the primary group from the logged in user.
    /// If the primary group is already a layer group, this group will be returned.
    /// </summary>
    /// <returns>Layergroup.</returns>
    public async Task<Group> ReceiveLayerGroupOfLoggedInUser()
    {
        Group primaryGroup = await ReceiveGroupByIdAsync(_primaryGroupId);
        return await ReceiveLayerGroupFromGroup(primaryGroup);
    }
        
    public static async Task<MiDataAccess> CreateInstanceAsync(string serviceToken, string primaryGroupId)
    {
        var access = new MiDataAccess(serviceToken, primaryGroupId);

        await access.ReceiveGroupByIdAsync(primaryGroupId);

        return access;
    }


    /// <summary>
    /// Receives the Layergroup of the given group. If the group is already a layer group,
    /// the method returns the given group.
    /// </summary>
    /// <param name="group">The group for which the layergroup is searched.</param>
    /// <returns>Layergroup of the given group.</returns>
    private async Task<Group> ReceiveLayerGroupFromGroup(Group group)
    {
        if (group.IsLayerGroup)
        {
            return group;
        }
        return await ReceiveGroupByIdAsync(group.LayerGroupId);
    }

    /// <summary>
    /// Receives all subgroups of a given group. 
    /// </summary>
    /// <param name="group">The group of which the subgroups should be returned.</param>
    /// <param name="recursive">Determines if the subgroups of the subgroups should be included recursively.</param>
    /// <returns>Set of subgroups.</returns>
    private async Task<List<Group>> ReceiveAllSubGroupsFromGroupAsync(Group group, bool recursive = false)
    {
        List<Group> groups = new List<Group>();
        if (group.ChildGroupIds != null)
        {
            foreach (string childGroupId in group.ChildGroupIds)
            {
                var childGroup = await ReceiveGroupByIdAsync(childGroupId);
                groups.Add(childGroup);
                if (recursive)
                {
                    var subGroups = await ReceiveAllSubGroupsFromGroupAsync(childGroup, true);
                    groups.AddRange(subGroups);
                }
            }
        }
        return groups;
    }

    /// <summary>
    /// Receives the all groups from the layergroup of the logged in user. The primary group of the user
    /// is used for determining the next layergroup. The parameter <paramref name="recursive"/> determines
    /// only the subgroups of the layergroup should be returned or if all subgroups of all groups should be
    /// returned recursively. The Layergroup itself is included.
    /// </summary>
    /// <param name="recursive">Determines if the groups should be returned recursively or not.</param>
    /// <returns>All subgroups of the layergroup.</returns>
    private async Task<IEnumerable<Group>> ReceiveAllGroupsFromLayerGroupAsync(bool recursive)
    {
        var layerGroup = await ReceiveLayerGroupOfLoggedInUser();

        var subGroups = await ReceiveAllSubGroupsFromGroupAsync(layerGroup, recursive);

        subGroups.Add(layerGroup);

        return subGroups;
    }

    /// <summary>
    /// Receives a group according to its id from the web server.
    /// </summary>
    /// <param name="groupId">The id of the group.</param>
    /// <returns>The <see cref="Group"/> instance.</returns>
    private async Task<Group> ReceiveGroupByIdAsync(string groupId)
    {
        string jsonResponse = await ReceiveJsonStringContentAsync(string.Format(UrlConstants.GroupDetailsUrlFormatString, groupId));

        return JsonParser.ParseGroup(jsonResponse);
    }

    /// <summary>
    /// Generalized method to Receive any json string from the given url.
    /// </summary>
    /// <param name="uri">The uri part to send the request to.</param>
    /// <returns>Json string.</returns>
    private async Task<string> ReceiveJsonStringContentAsync(string uri)
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
    /// Creates a request message to the given uri with the given method.
    /// </summary>
    /// <param name="uri">The uri to request.</param>
    /// <param name="method">The method to use.</param>
    /// <returns>The created <see cref="HttpRequestMessage"/>.</returns>
    private HttpRequestMessage CreateRequestMessage(string uri, HttpMethod method)
    {
        HttpRequestMessage message = new HttpRequestMessage(method, uri);
        message.Headers.Add("X-Token", _serviceToken);
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
    /// <returns>The formatted string.</returns>
    private static string FormatHttpErrorMessage(HttpResponseMessage response)
    {
        return $"{response.StatusCode} - {response.ReasonPhrase}\n\nResponse:\n{response.Content.ReadAsStringAsync().Result}";
    }

    /// <summary>
    /// Creates an Uri with the given path and parameters. <para>urlWithoutParameters</para> must not
    /// have any parameters in it!
    /// </summary>
    /// <param name="urlWithoutParameters">An url (relative or absolute) without any parameters.</param>
    /// <param name="parameterValueCollection">A dictionary containing the parameter name as the key and its value as the values.</param>
    /// <returns>The uri with the given path and parameters.</returns>
    private static Uri CreateUriWithParameters(string urlWithoutParameters, Dictionary<string, string> parameterValueCollection)
    {
        var parameterValueProjection = parameterValueCollection
            .Select(keyValuePair => $"{keyValuePair.Key}={keyValuePair.Value}");
        string queryString = "?" + string.Join("&", parameterValueProjection);
        return new Uri(urlWithoutParameters + queryString);
    }

    /// <summary>
    /// Creates the correctly preconfigured <see cref="HttpClient"/> with the BaseAddress property already set. Use always this method.
    /// </summary>
    /// <returns>The correctly preconfigured <see cref="HttpClient"/> to communicate with the PBS DB.</returns>
    private static HttpClient CreateHttpClient()
    {
        return new HttpClient { BaseAddress = new Uri(UrlConstants.BaseUrl) };
    }
}