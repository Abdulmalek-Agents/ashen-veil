using UnityEngine;
using System.Collections.Generic;
namespace AshenVeil.Combat
{
    public interface IDamageable { void TakeDamage(int amount); }
    [RequireComponent(typeof(Collider))]
    public class HitboxComponent : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        [SerializeField] private string targetTag = "Enemy";
        public bool Active { get; set; }
        private readonly HashSet<Collider> _hit = new();
        public void Open() { Active = true; _hit.Clear(); }
        public void Close() { Active = false; }
        private void OnTriggerEnter(Collider o) { if (!Active || !o.CompareTag(targetTag) || _hit.Contains(o)) return; _hit.Add(o); if (o.TryGetComponent<IDamageable>(out var d)) d.TakeDamage(damage); }
    }
}
