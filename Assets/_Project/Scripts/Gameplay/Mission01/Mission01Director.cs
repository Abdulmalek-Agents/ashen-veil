using UnityEngine;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace AshenVeil.MissionOne
{
    public class Mission01Director : MonoBehaviour
    {
        [SerializeField] private string missionId = "M01";
        [SerializeField] private Transform playerSpawn;
        [SerializeField] private GameObject openingCutscene, completionPanel;
        private IMissionService _m;
        private void Start() { _m = ServiceLocator.Get<IMissionService>(); _m.OnMissionCompleted += C; var p = GameObject.FindWithTag("Player"); if (p && playerSpawn) p.transform.SetPositionAndRotation(playerSpawn.position, playerSpawn.rotation); if (openingCutscene) openingCutscene.SetActive(true); }
        private void OnDestroy() { if (_m != null) _m.OnMissionCompleted -= C; }
        private void C(MissionDataSO m) { if (m.missionId == missionId && completionPanel) completionPanel.SetActive(true); }
    }
}
