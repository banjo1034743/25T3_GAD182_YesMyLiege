using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class SheepAppleEater : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private bool _hasEatenApple;

        [Header("Scripts")]

        [SerializeField] private SheepController _sheepController;

        #endregion

        #region Methods

        public bool GetHasEatenApple()
        {
            return _hasEatenApple;
        }

        private void EatApple(GameObject collidedObject)
        {
            if (collidedObject.CompareTag("Apple"))
            {
                AppleManager.instance.UpdateAppleCount(-1);
                _sheepController.ExitPen();
                // Call PlaySheepSFX(1, transform.position) in SheepSoundPlayer
            }
        }

        #endregion

        #region Unity Methods

        private void OnTriggerEnter(Collider other)
        {
            EatApple(other.gameObject);
        }

        #endregion
    }
}