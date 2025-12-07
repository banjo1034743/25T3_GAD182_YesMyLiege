using UnityEngine;

namespace DirtPoorPeasants.WinLoseSequence
{
    /// <summary>
    /// This class handles the sound efffects of the trumpets in
    /// the win and lose sequences
    /// </summary>
    public class TrumpetSoundPlayer : MonoBehaviour
    {
        #region Variabes

        [Header("Sound Effect Player")]

        [SerializeField] private AudioSource _audioSource;

        [Header("Sound Effects")]

        [SerializeField] private AudioClip[] _audioClips;

        #endregion

        #region Methods

        /// <summary>
        /// This method is called in the animation clips themselves through
        /// Animation Events. The int passed through the method will specify
        /// to play either the winning noise (0), or the losing noise (1).
        /// </summary>
        /// <param name="soundEffectToPlay"></param>
        public void PlaySFX(int soundEffectToPlay)
        {
            _audioSource.PlayOneShot(_audioClips[soundEffectToPlay]);
        }

        #endregion
    }
}