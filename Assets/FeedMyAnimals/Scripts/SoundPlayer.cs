using UnityEngine;
using UnityEngine.Audio;

namespace DirtPoorPeasants
{
    /// <summary>
    /// This is the base class the all SoundPlayer scripts inherit from
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public abstract class SoundPlayer : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected AudioClip[] _soundEffects;

        [SerializeField] protected AudioSource _audioSource;

        [SerializeField] protected AudioMixerGroup _audioMixerGroup;

        [SerializeField] protected GameObject _instantiatedAudioSource;

        #endregion

        #region Methods

        public abstract void PlaySFX(int soundEffectIndex);

        public abstract void PlaySFXAtPosition(int soundEffectIndex, Vector3 positionToPlay);

        public virtual void PlayClipAt(int soundEffectIndex, Vector3 pos, float volume)
        {
            // Ransaked code
            AudioSource aSource = Instantiate(_instantiatedAudioSource).GetComponent<AudioSource>();
            aSource.gameObject.transform.position = pos;
            aSource.clip = _soundEffects[soundEffectIndex];
            aSource.volume = volume;

            aSource.PlayOneShot(_soundEffects[soundEffectIndex]);
            Destroy(aSource.gameObject, _soundEffects[soundEffectIndex].length);
        }

        #endregion
    }
}