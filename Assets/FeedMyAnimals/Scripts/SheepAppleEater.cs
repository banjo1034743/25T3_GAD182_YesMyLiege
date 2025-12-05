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
            if (collidedObject.CompareTag("Apple") && !_hasEatenApple)
            {
                AppleManager.instance.UpdateAppleCount(-1);
                _sheepController.BeginExitPenCoroutine();
                _sheepSoundPlayer.PlayClipAt(0, transform.position, 0.5f);
                _sheepSoundPlayer.PlayClipAt(1, transform.position, 0.5f);
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