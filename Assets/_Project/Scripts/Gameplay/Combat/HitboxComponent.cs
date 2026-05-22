using UnityEngine;
using System.Collections.Generic;
namespace AshenVeil.Combat
{
    [RequireComponent(typeof(Collider))]
    public class HitboxComponent : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        [SerializeField] private string targetTag = "Enemy";
        public bool Active { get; set; }
        private readonly HashSet<Collider> _hitOnce = new();

        public void Open() { Active = true; _hitOnce.Clear(); }
        public void Close() { Active = false; }

        private void OnTriggerEnter(Collider other)
        {
            if (!Active || !other.CompareTag(targetTag) || _hitOnce.Contains(other)) return;
            _hitOnce.Add(other);
            if (other.TryGetComponent<IDamageable>(out var d)) d.TakeDamage(damage);
        }
    }
    public interface IDamageable { void TakeDamage(int amount); }
}
