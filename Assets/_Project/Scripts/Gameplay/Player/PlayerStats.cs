using UnityEngine;
using UnityEngine.Events;
namespace AshenVeil.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        public int Current { get; private set; }
        public UnityEvent<int, int> OnHealthChanged;
        public UnityEvent OnDied;
        private void Awake() { Current = maxHealth; }
        public void TakeDamage(int a) { Current = Mathf.Max(0, Current - a); OnHealthChanged?.Invoke(Current, maxHealth); if (Current == 0) OnDied?.Invoke(); }
        public void Heal(int a) { Current = Mathf.Min(maxHealth, Current + a); OnHealthChanged?.Invoke(Current, maxHealth); }
    }
    public class PlayerStamina : MonoBehaviour
    {
        [SerializeField] private float maxStamina = 80f, regenPerSec = 30f, regenDelaySec = 0.6f;
        public float Current { get; private set; }
        private float _lastUseTime;
        private void Awake() { Current = maxStamina; }
        public bool TryConsume(float a) { if (Current < a) return false; Current -= a; _lastUseTime = Time.time; return true; }
        private void Update() { if (Time.time - _lastUseTime < regenDelaySec) return; Current = Mathf.Min(maxStamina, Current + regenPerSec * Time.deltaTime); }
    }
}
