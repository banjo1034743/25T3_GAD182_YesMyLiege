using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class EatenChecker : MonoBehaviour
    {
        #region Variables

        [SerializeField] private bool _hasBeenEaten;

        #endregion

        #region Methods

        public bool GetHasBeenEatenValue()
        {
            return _hasBeenEaten;
        }

        #endregion

        #region Unity Methods

        private void OnTriggerEnter(Collider other)
        {
            // set variable to true if the collider is tagged as sheep
            if (other.gameObject.CompareTag("Sheep"))
            {
                _hasBeenEaten = true;
            }
        }

        #endregion
    }
}