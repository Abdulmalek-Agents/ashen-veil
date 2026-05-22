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
        public void TakeDamage(int amount) { Current = Mathf.Max(0, Current - amount); OnHealthChanged?.Invoke(Current, maxHealth); if (Current == 0) OnDied?.Invoke(); }
        public void Heal(int amount) { Current = Mathf.Min(maxHealth, Current + amount); OnHealthChanged?.Invoke(Current, maxHealth); }
    }
}
