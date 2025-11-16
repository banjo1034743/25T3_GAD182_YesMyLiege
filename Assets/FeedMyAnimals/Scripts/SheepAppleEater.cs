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

        // We reference this to get access to the PlaySFX() method.
        [SerializeField] private SheepSoundPlayer _sheepSoundPlayer;

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
                StartCoroutine(_sheepController.ExitPen());
                _sheepSoundPlayer.PlaySFX(1, transform.position);
                _hasEatenApple = true;
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