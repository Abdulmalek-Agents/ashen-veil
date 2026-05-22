using UnityEngine;
using InventixGames.Core.Dialogue;

namespace AshenVeil.Bonfires
{
    /// <summary>
    /// The Echo (a fragment of the slumbering god in your soul) whispers a hand-authored
    /// line when the player rests at a bonfire. v0.2: lines come from a LineBankSO,
    /// not from a runtime LLM. Bonfire mechanics live in BonfireCheckpoint.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class BonfireEcho : MonoBehaviour
    {
        [SerializeField] private LineBankSO whisperBank;
        [SerializeField] private LineBankSO firstRestBank;     // optional one-time first-rest variant
        [SerializeField] private bool playOnceOnFirstRest = true;
        private bool _firstRestDone;
        private AudioSource _audio;

        private void Awake() { _audio = GetComponent<AudioSource>(); }

        public void OnPlayerRested()
        {
            LineBankSO pick = (playOnceOnFirstRest && !_firstRestDone && firstRestBank != null) ? firstRestBank : whisperBank;
            if (pick == null) return;
            string line = pick.PickRandom(out var clip);
            _firstRestDone = true;
            if (_audio && clip) { _audio.clip = clip; _audio.Play(); }
            // Pipe to the subtitle UI of your choice.
            Debug.Log($"[Echo] {line}");
        }
    }
}
