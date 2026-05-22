using UnityEngine;
using InventixGames.Core;

namespace AshenVeil.Bonfires
{
    [RequireComponent(typeof(Collider))]
    public class BonfireCheckpoint : MonoBehaviour
    {
        [SerializeField] private string bonfireId;
        [SerializeField] private GameObject lightFx;
        [SerializeField] private BonfireEcho echo;

        public void Light()
        {
            if (lightFx) lightFx.SetActive(true);
            if (ServiceLocator.TryGet<ICheckpointService>(out var c)) c.Register(transform.position, bonfireId);
            if (ServiceLocator.TryGet<ISaveService>(out var s)) s.Save();
            if (echo != null) echo.OnPlayerRested();
        }
        private void OnTriggerEnter(Collider o) { if (o.CompareTag("Player")) Light(); }
    }
}
