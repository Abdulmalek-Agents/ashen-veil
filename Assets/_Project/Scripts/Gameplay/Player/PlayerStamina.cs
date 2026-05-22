using UnityEngine;
namespace AshenVeil.Player
{
    public class PlayerStamina : MonoBehaviour
    {
        [SerializeField] private float maxStamina = 80f;
        [SerializeField] private float regenPerSec = 30f;
        [SerializeField] private float regenDelaySec = 0.6f;
        public float Current { get; private set; }
        private float _lastUseTime;
        private void Awake() { Current = maxStamina; }
        public bool TryConsume(float amount) { if (Current < amount) return false; Current -= amount; _lastUseTime = Time.time; return true; }
        private void Update() { if (Time.time - _lastUseTime < regenDelaySec) return; Current = Mathf.Min(maxStamina, Current + regenPerSec * Time.deltaTime); }
    }
}
