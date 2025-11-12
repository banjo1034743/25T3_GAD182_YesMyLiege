using UnityEngine;

namespace DirtPoorPeasants
{
    /// <summary>
    /// This is the base class the all SoundPlayer scripts inherit from
    /// </summary>
    public abstract class SoundPlayer : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected AudioClip[] _soundEffects;

        #endregion

        #region Methods

        public abstract void PlaySFX(int soundEffectIndex, Vector3 positionToPlay);

        #endregion
    }
}