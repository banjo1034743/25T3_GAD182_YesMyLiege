using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class GronknoliusSoundPlayer : SoundPlayer
    {
        #region Methods

        public override void PlaySFX(int soundEffectIndex, Vector3 positionToPlay)
        {
            AudioSource.PlayClipAtPoint(_soundEffects[soundEffectIndex], positionToPlay);
        }

        #endregion
    }
}