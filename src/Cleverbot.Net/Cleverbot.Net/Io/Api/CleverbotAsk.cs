﻿using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cleverbot.Net.Io.Api
{
    public static class CleverbotAskApi
    {
        private const string CleverbotAskApiUrl = @"https://cleverbot.io/1.0/ask";
        public static async Task<CleverbotAskResponse> GetResponseAsync(CleverbotAskRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var result = await CleverbotUserAgent.PostAsync(CleverbotAskApiUrl, json);
            return JsonConvert.DeserializeObject<CleverbotAskResponse>(result);
        }
    }
    public class CleverbotAskRequest
    {
        [JsonProperty(PropertyName = "user")]
        public string User { get; }
        [JsonProperty(PropertyName = "key")]
        public string Key { get; }
        [JsonProperty(PropertyName = "nick")]
        public string Nick { get; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; }

        public CleverbotAskRequest(string user, string key, string nick, string text)
        {
            User = user;
            Key = key;
            Nick = nick;
            Text = text;
        }
    }
    public class CleverbotAskResponse
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; }
        [JsonProperty(PropertyName = "response")]
        public string Response { get; }

        public CleverbotAskResponse(string status, string response)
        {
            Status = status;
            Response = response;
        }
    }
}
