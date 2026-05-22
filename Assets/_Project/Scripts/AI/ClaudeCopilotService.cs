using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
namespace InventixGames.Core
{
    public interface IAICopilotService { void Ask(string sys, string user, Action<string> done, Action<string> onToken = null); void RememberFact(string npcId, string fact); IReadOnlyList<string> GetMemory(string npcId); }
    public class ClaudeCopilotService : MonoBehaviour, IAICopilotService
    {
        [SerializeField] private string proxyUrl = "http://localhost:8787/v1/messages";
        [SerializeField] private string model = "claude-sonnet-4-5";
        [SerializeField, Range(64, 4096)] private int maxTokens = 512;
        [SerializeField] private string[] offlineFallbacks = { "The veil grows thick. Speak again, small flame.", "...your god dreams. I cannot reach you now." };
        private readonly Dictionary<string, List<string>> _memory = new();

        public void Ask(string sys, string user, Action<string> done, Action<string> onToken = null) => StartCoroutine(R(sys, user, done));
        private IEnumerator R(string sys, string user, Action<string> done)
        {
            var body = new RequestBody { model = model, max_tokens = maxTokens, system = sys, messages = new[] { new Message { role = "user", content = user } } };
            string json = JsonUtility.ToJson(body);
            using var req = new UnityWebRequest(proxyUrl, "POST") { uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json)), downloadHandler = new DownloadHandlerBuffer(), timeout = 30 };
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            if (req.result != UnityWebRequest.Result.Success) { done?.Invoke(offlineFallbacks[UnityEngine.Random.Range(0, offlineFallbacks.Length)]); yield break; }
            try { var resp = JsonUtility.FromJson<ResponseBody>(req.downloadHandler.text); done?.Invoke(resp?.content != null && resp.content.Length > 0 ? resp.content[0].text : "..."); } catch { done?.Invoke(offlineFallbacks[0]); }
        }
        public void RememberFact(string npcId, string fact) { if (!_memory.TryGetValue(npcId, out var l)) _memory[npcId] = l = new List<string>(); l.Add(fact); if (l.Count > 32) l.RemoveAt(0); }
        public IReadOnlyList<string> GetMemory(string npcId) => _memory.TryGetValue(npcId, out var l) ? (IReadOnlyList<string>)l : Array.Empty<string>();
        [Serializable] private class RequestBody { public string model; public int max_tokens; public string system; public Message[] messages; }
        [Serializable] private class Message { public string role; public string content; }
        [Serializable] private class ResponseBody { public ContentBlock[] content; }
        [Serializable] private class ContentBlock { public string type; public string text; }
    }
}
