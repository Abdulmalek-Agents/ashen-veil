using UnityEngine;
using UnityEngine.InputSystem;
namespace AshenVeil.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerStamina stamina;
        [SerializeField] private float lightStamCost = 12f;
        [SerializeField] private float heavyStamCost = 25f;
        [SerializeField] private float dodgeStamCost = 20f;
        [SerializeField] private float parryWindowSec = 0.25f;
        public bool IsParrying { get; private set; }
        public bool IsDodging { get; private set; }

        public void OnLightAttack(InputAction.CallbackContext ctx) { if (ctx.performed && stamina.TryConsume(lightStamCost)) animator.SetTrigger("LightAttack"); }
        public void OnHeavyAttack(InputAction.CallbackContext ctx) { if (ctx.performed && stamina.TryConsume(heavyStamCost)) animator.SetTrigger("HeavyAttack"); }
        public void OnDodge(InputAction.CallbackContext ctx) { if (ctx.performed && stamina.TryConsume(dodgeStamCost)) { animator.SetTrigger("Dodge"); StartCoroutine(DodgeIFrames()); } }
        public void OnParry(InputAction.CallbackContext ctx) { if (ctx.performed) StartCoroutine(ParryWindow()); }

        private System.Collections.IEnumerator ParryWindow() { IsParrying = true; yield return new WaitForSeconds(parryWindowSec); IsParrying = false; }
        private System.Collections.IEnumerator DodgeIFrames() { IsDodging = true; yield return new WaitForSeconds(0.4f); IsDodging = false; }
    }
}
