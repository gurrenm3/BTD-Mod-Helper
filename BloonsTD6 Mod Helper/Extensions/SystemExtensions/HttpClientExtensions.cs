using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for HttpClient
/// </summary>
public static class HttpClientExtensions
{
    /// <summary>
    /// Version of <see cref="HttpClient.GetByteArrayAsync(string?, CancellationToken)"/> that passes in an auth header value
    /// </summary>
    public static async Task<byte[]> GetBytesWithAuthAsync(this HttpClient client, string requestUri, string auth = null,
        CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        if (!string.IsNullOrEmpty(auth))
        {
            request.Headers.Authorization = AuthenticationHeaderValue.Parse(auth);
        }

        using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct)
            .ConfigureAwait(false);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            throw new HttpRequestException($"Got error status code for request to {requestUri}", e);
        }
        return await response.Content.ReadAsByteArrayAsync(ct).ConfigureAwait(false);
    }

    /// <summary>
    /// Version of <see cref="HttpClient.GetStringAsync(string?, CancellationToken)"/> that passes in an auth header value
    /// </summary>
    public static async Task<string> GetStringWithAuthAsync(this HttpClient client, string requestUri, string auth = null,
        CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        if (!string.IsNullOrEmpty(auth))
        {
            request.Headers.Authorization = AuthenticationHeaderValue.Parse(auth);
        }

        using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct)
            .ConfigureAwait(false);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            throw new HttpRequestException($"Got error status code for request to {requestUri}", e);
        }
        return await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);
    }

    extension(JObject)
    {
        internal static async Task<JObject> LoadAsync(string text, CancellationToken ct = default)
        {
            using var stringReader = new StringReader(text);
            await using var reader = new JsonTextReader(stringReader);
            return await JObject.LoadAsync(reader, ct);
        }
    }
}