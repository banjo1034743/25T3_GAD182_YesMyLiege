using UnityEngine;

namespace DirtPoorPeasants.WinLoseSequence
{
    /// <summary>
    /// This class handles the switching on and off of the trumpet
    /// playing sequence. It can be specified here whether you want
    /// the victory or lose squence to be played
    /// </summary>
    public class TrumpetEnabler : MonoBehaviour
    {
        #region Variables

        [Tooltip("This is what handles knowing which animation for the trumpets to play depending on if we win or lose. The code specifies this for the controller by switching on or off parameters in the controller that the controller reads and uses to switch to the wanted animation")]
        [SerializeField] private Animator[] _trumpetAnimator;

        [Tooltip("This is the actual screen itself with the trumpets in a canvas as UI. It's enabled after we specify what animation to play with the parameters, which after enabling will go and play the animation based on what parameters we specified.")]
        [SerializeField] private GameObject _trumpetSequenceScreen;

        #endregion

        #region Methods

        /// <summary>
        /// This method plays the trumpet sequence for a successful completion
        /// of the microgame. It will play a victorius trumpet noise. Call this
        /// method when the player completes the microgame completley
        /// </summary>
        public void EnableWinSequence()
        {
            // This sets the hasWon parameter to true, and hasLost to false.
            // We use ids so as not to break code if name was changed
            _trumpetAnimator[0].SetBool(0, true);
            _trumpetAnimator[0].SetBool(1, false);

            _trumpetAnimator[1].SetBool(0, true);
            _trumpetAnimator[1].SetBool(1, false);

            _trumpetSequenceScreen.SetActive(true);
        }

        /// <summary>
        /// This method plays the trumpet sequence for a loss of the microgame.
        /// Call this when the player fails your microgame.
        /// </summary>
        public void EnableLoseSequence()
        {
            _trumpetAnimator[0].SetBool(0, false);
            _trumpetAnimator[0].SetBool(1, true);

            _trumpetAnimator[1].SetBool(0, false);
            _trumpetAnimator[1].SetBool(1, true);

            _trumpetSequenceScreen.SetActive(true);
        }

        #endregion
    }
}