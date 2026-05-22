using UnityEngine;
using System.Collections.Generic;
namespace InventixGames.Core.Mission
{
    [CreateAssetMenu(menuName = "Inventix/Mission/Mission Data", fileName = "MissionData_")]
    public class MissionDataSO : ScriptableObject
    {
        public string missionId = "M01";
        public string displayName = "Mission";
        [TextArea(3, 6)] public string briefingText;
        public string sceneName;
        public string addressableSceneKey;
        public float targetDurationMinutes = 12f;
        public List<MissionObjective> objectives = new();
        public List<string> prerequisiteMissionIds = new();
        public int xpReward = 100;
        public int currencyReward = 50;
    }
    [System.Serializable]
    public class MissionObjective { public string objectiveId; public string description; public ObjectiveType type; public int targetCount = 1; public bool optional; }
    public enum ObjectiveType { ReachLocation, DefeatEnemies, CollectItems, InteractWith, EscortNpc, Survive, Custom }
}
