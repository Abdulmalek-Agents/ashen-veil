using UnityEngine;
using UnityEngine.AI;
using AshenVeil.Combat;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace AshenVeil.Enemy
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
    public class EnemyController : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 30;
        [SerializeField] private float aggroRange = 8f;
        [SerializeField] private float attackRange = 1.6f;
        [SerializeField] private string objectiveOnDeath;
        private NavMeshAgent _agent; private Animator _anim;
        private Transform _player;
        private int _hp;

        private void Awake() { _agent = GetComponent<NavMeshAgent>(); _anim = GetComponent<Animator>(); _hp = maxHealth; var p = GameObject.FindWithTag("Player"); if (p) _player = p.transform; }

        private void Update()
        {
            if (_player == null || _hp <= 0) return;
            float dist = Vector3.Distance(transform.position, _player.position);
            if (dist > aggroRange) { _agent.isStopped = true; _anim.SetBool("Run", false); return; }
            if (dist > attackRange) { _agent.isStopped = false; _agent.SetDestination(_player.position); _anim.SetBool("Run", true); }
            else { _agent.isStopped = true; _anim.SetBool("Run", false); _anim.SetTrigger("Attack"); }
        }

        public void TakeDamage(int amount)
        {
            _hp -= amount;
            _anim.SetTrigger("Hit");
            if (_hp <= 0) Die();
        }
        private void Die()
        {
            _anim.SetTrigger("Die");
            _agent.enabled = false;
            if (!string.IsNullOrEmpty(objectiveOnDeath) && ServiceLocator.TryGet<IMissionService>(out var ms))
                ms.ReportObjectiveProgress(objectiveOnDeath);
            Destroy(gameObject, 4f);
        }
    }
}
