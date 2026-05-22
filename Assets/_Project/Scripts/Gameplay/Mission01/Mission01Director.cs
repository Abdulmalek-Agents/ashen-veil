using UnityEngine;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace AshenVeil.MissionOne
{
    public class Mission01Director : MonoBehaviour
    {
        [SerializeField] private string missionId = "M01";
        [SerializeField] private Transform playerSpawn;
        [SerializeField] private GameObject openingCutscene;
        [SerializeField] private GameObject completionPanel;
        private IMissionService _mission;

        private void Start()
        {
            _mission = ServiceLocator.Get<IMissionService>();
            _mission.OnMissionCompleted += OnComplete;
            var p = GameObject.FindWithTag("Player");
            if (p && playerSpawn) p.transform.SetPositionAndRotation(playerSpawn.position, playerSpawn.rotation);
            if (openingCutscene) openingCutscene.SetActive(true);
        }
        private void OnDestroy() { if (_mission != null) _mission.OnMissionCompleted -= OnComplete; }
        private void OnComplete(MissionDataSO m) { if (m.missionId == missionId && completionPanel) completionPanel.SetActive(true); }
    }
}
