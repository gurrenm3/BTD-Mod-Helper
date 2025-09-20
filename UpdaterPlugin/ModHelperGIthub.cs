using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace UpdaterPlugin;

internal static class ModHelperGithub
{
    public const string RawUserContent = "https://raw.githubusercontent.com";

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