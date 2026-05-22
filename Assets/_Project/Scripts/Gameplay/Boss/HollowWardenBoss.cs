using UnityEngine;
using AshenVeil.Combat;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace AshenVeil.Bosses
{
    public enum WardenPhase { Idle, PhaseOne, PhaseTwo, Dead }
    public class HollowWardenBoss : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 250;
        [SerializeField] private float phaseTwoThreshold = 0.5f;
        [SerializeField] private Animator animator;
        [SerializeField] private string objectiveOnDeath = "m1_defeat_warden";
        [SerializeField] private GameObject phaseTransitionVfx;
        private int _hp;
        public WardenPhase Phase { get; private set; }
        private void Awake() { _hp = maxHealth; Phase = WardenPhase.PhaseOne; }
        public void TakeDamage(int a)
        {
            if (Phase == WardenPhase.Dead) return;
            _hp -= a; animator.SetTrigger("Hit");
            if (Phase == WardenPhase.PhaseOne && _hp <= maxHealth * phaseTwoThreshold) { Phase = WardenPhase.PhaseTwo; if (phaseTransitionVfx) Instantiate(phaseTransitionVfx, transform.position, Quaternion.identity); animator.SetTrigger("PhaseTwo"); }
            if (_hp <= 0) { Phase = WardenPhase.Dead; animator.SetTrigger("Die"); if (ServiceLocator.TryGet<IMissionService>(out var ms)) ms.ReportObjectiveProgress(objectiveOnDeath); }
        }
    }
}
