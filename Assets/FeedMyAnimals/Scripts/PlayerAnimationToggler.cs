using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class PlayerAnimationToggler : MonoBehaviour
    {
        #region Variables

        [Header("Components")]

        [SerializeField] private Animator _playerAnimator;

        [Header("Scripts")]

        [SerializeField] private PlayerMover _playerMover;

        #endregion

        #region Methods

        public void ToggleMoveAnimation(bool valueToSetParameterTo)
        {
            _playerAnimator.SetBool("isMoving", valueToSetParameterTo);
        }

        public bool GetIsMovingValue()
        {
            return _playerAnimator.GetBool("isMoving");
        }

        #endregion
    }
}