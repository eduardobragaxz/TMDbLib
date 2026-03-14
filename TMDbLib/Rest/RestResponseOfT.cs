using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TMDbLib.Utilities;

namespace TMDbLib.Rest;

#pragma warning disable SA1649 // File name should match first type name (generic types cannot match file names)
internal class RestResponse<T> : RestResponse
#pragma warning restore SA1649
{
    private readonly RestClient _client;

    public RestResponse(HttpResponseMessage? response, RestClient client)
        : base(response)
    {
        _client = client;
    }

    public async Task<T?> GetDataObject()
    {
        if (!IsValid)
        {
            return default;
        }

        using Stream content = await GetContent().ConfigureAwait(false);
        var result = _client.Serializer.Deserialize<T>(content);

        return result is T typed ? typed : default;
    }
}
