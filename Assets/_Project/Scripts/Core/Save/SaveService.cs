using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace InventixGames.Core
{
    public interface ISaveService { SaveData Data { get; } void Save(); void Load(); void MarkMissionComplete(string id); bool IsMissionComplete(string id); }
    [Serializable] public class SaveData { public List<string> completedMissionIds = new(); public int currency; public int xp; public Dictionary<string, string> kv = new(); }
    public class JsonSaveService : ISaveService
    {
        private const string F = "save.json";
        public SaveData Data { get; private set; } = new();
        public JsonSaveService() { Load(); }
        private string P => Path.Combine(Application.persistentDataPath, F);
        public void Save() => File.WriteAllText(P, JsonUtility.ToJson(Data, true));
        public void Load() { try { if (File.Exists(P)) Data = JsonUtility.FromJson<SaveData>(File.ReadAllText(P)) ?? new SaveData(); } catch { Data = new SaveData(); } }
        public void MarkMissionComplete(string id) { if (!Data.completedMissionIds.Contains(id)) Data.completedMissionIds.Add(id); Save(); }
        public bool IsMissionComplete(string id) => Data.completedMissionIds.Contains(id);
    }
}
