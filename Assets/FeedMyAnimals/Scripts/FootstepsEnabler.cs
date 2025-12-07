using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class FootstepsEnabler : MonoBehaviour
    {
        #region

        [SerializeField] private GameObject _footStepsObject;

        [SerializeField] private PlayerAnimationToggler _playerAnimationToggler;

        #endregion

        #region Methods

        private void ToggleFootstepsObject()
        {
            _footStepsObject.SetActive(_playerAnimationToggler.GetIsMovingValue());
        }

        #endregion

        #region Unity Methods

        // Update is called once per frame
        void Update()
        {
            ToggleFootstepsObject();
        }

        #endregion
    }
}