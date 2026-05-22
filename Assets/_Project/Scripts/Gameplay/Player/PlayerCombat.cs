using UnityEngine;
using UnityEngine.InputSystem;
namespace AshenVeil.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerStamina stamina;
        [SerializeField] private float lightCost = 12f, heavyCost = 25f, dodgeCost = 20f, parryWindow = 0.25f;
        public bool IsParrying { get; private set; }
        public bool IsDodging { get; private set; }
        public void OnLightAttack(InputAction.CallbackContext c) { if (c.performed && stamina.TryConsume(lightCost)) animator.SetTrigger("LightAttack"); }
        public void OnHeavyAttack(InputAction.CallbackContext c) { if (c.performed && stamina.TryConsume(heavyCost)) animator.SetTrigger("HeavyAttack"); }
        public void OnDodge(InputAction.CallbackContext c) { if (c.performed && stamina.TryConsume(dodgeCost)) { animator.SetTrigger("Dodge"); StartCoroutine(D()); } }
        public void OnParry(InputAction.CallbackContext c) { if (c.performed) StartCoroutine(P()); }
        private System.Collections.IEnumerator P() { IsParrying = true; yield return new WaitForSeconds(parryWindow); IsParrying = false; }
        private System.Collections.IEnumerator D() { IsDodging = true; yield return new WaitForSeconds(0.4f); IsDodging = false; }
    }
}
