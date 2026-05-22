using UnityEngine;
using InventixGames.Core;
namespace AshenVeil.Bonfires
{
    [RequireComponent(typeof(Collider))]
    public class BonfireCheckpoint : MonoBehaviour
    {
        [SerializeField] private string bonfireId;
        [SerializeField] private GameObject lightFx;

        public void Light()
        {
            if (lightFx) lightFx.SetActive(true);
            if (ServiceLocator.TryGet<ICheckpointService>(out var c)) c.Register(transform.position, bonfireId);
            if (ServiceLocator.TryGet<ISaveService>(out var s)) s.Save();
        }

        private void OnTriggerEnter(Collider other) { if (other.CompareTag("Player")) Light(); }
    }
}
