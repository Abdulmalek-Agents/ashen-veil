using UnityEngine;
using UnityEngine.Audio;
namespace InventixGames.Core
{
    public interface IAudioService { void PlaySfx(AudioClip c, float v = 1f); void PlayMusic(AudioClip c, bool loop = true); void StopMusic(); void SetMasterVolume(float v); }
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField] private AudioMixer mixer; [SerializeField] private AudioSource musicSource; [SerializeField] private AudioSource sfxSource;
        private void Awake() { if (!musicSource) musicSource = gameObject.AddComponent<AudioSource>(); if (!sfxSource) sfxSource = gameObject.AddComponent<AudioSource>(); musicSource.playOnAwake = false; sfxSource.playOnAwake = false; }
        public void PlaySfx(AudioClip c, float v = 1f) { if (c) sfxSource.PlayOneShot(c, v); }
        public void PlayMusic(AudioClip c, bool loop = true) { if (!c) return; musicSource.clip = c; musicSource.loop = loop; musicSource.Play(); }
        public void StopMusic() => musicSource.Stop();
        public void SetMasterVolume(float v) { if (mixer) mixer.SetFloat("MasterVolume", Mathf.Lerp(-80f, 0f, Mathf.Clamp01(v))); else AudioListener.volume = Mathf.Clamp01(v); }
    }
}
