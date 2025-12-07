using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    [RequireComponent(typeof(AudioSource))]
    public class GronknoliusSoundPlayer : SoundPlayer
    {
        #region Methods

        public override void PlaySFXAtPosition(int soundEffectIndex, Vector3 positionToPlay)
        {
            AudioSource.PlayClipAtPoint(_soundEffects[soundEffectIndex], positionToPlay);
        }

        public override void PlaySFX(int soundEffectIndex)
        {
            _audioSource.PlayOneShot(_soundEffects[soundEffectIndex]);
        }

        #endregion
    }
}