using UnityEngine;
using System;
using System.Collections.Generic;
namespace InventixGames.Core.Mission
{
    public interface IMissionService { MissionDataSO CurrentMission { get; } event Action<MissionDataSO> OnMissionStarted; event Action<MissionDataSO> OnMissionCompleted; event Action<MissionObjective> OnObjectiveUpdated; void StartMission(string missionId); void ReportObjectiveProgress(string objectiveId, int delta = 1); bool IsObjectiveComplete(string objectiveId); void CompleteMission(); }
    public class MissionManager : MonoBehaviour, IMissionService
    {
        [SerializeField] private MissionDatabaseSO database;
        public MissionDataSO CurrentMission { get; private set; }
        public event Action<MissionDataSO> OnMissionStarted;
        public event Action<MissionDataSO> OnMissionCompleted;
        public event Action<MissionObjective> OnObjectiveUpdated;
        private readonly Dictionary<string, int> _progress = new();
        public void StartMission(string id) { CurrentMission = database?.Get(id); if (CurrentMission == null) { Debug.LogError($"[Mission] {id} missing"); return; } _progress.Clear(); foreach (var o in CurrentMission.objectives) _progress[o.objectiveId] = 0; OnMissionStarted?.Invoke(CurrentMission); if (!string.IsNullOrEmpty(CurrentMission.sceneName)) SceneLoader.LoadSceneAsync(CurrentMission.sceneName); }
        public void ReportObjectiveProgress(string id, int d = 1) { if (CurrentMission == null || !_progress.ContainsKey(id)) return; var o = CurrentMission.objectives.Find(x => x.objectiveId == id); if (o == null) return; _progress[id] = Mathf.Min(o.targetCount, _progress[id] + d); OnObjectiveUpdated?.Invoke(o); if (AllDone()) CompleteMission(); }
        public bool IsObjectiveComplete(string id) { if (CurrentMission == null) return false; var o = CurrentMission.objectives.Find(x => x.objectiveId == id); return o != null && _progress.TryGetValue(id, out var c) && c >= o.targetCount; }
        public void CompleteMission() { if (CurrentMission == null) return; OnMissionCompleted?.Invoke(CurrentMission); if (ServiceLocator.TryGet<ISaveService>(out var s)) s.MarkMissionComplete(CurrentMission.missionId); }
        private bool AllDone() { foreach (var o in CurrentMission.objectives) { if (o.optional) continue; if (!_progress.TryGetValue(o.objectiveId, out var c) || c < o.targetCount) return false; } return true; }
    }
}
