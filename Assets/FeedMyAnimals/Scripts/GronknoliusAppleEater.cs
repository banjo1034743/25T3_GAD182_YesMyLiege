using UnityEngine;
using UnityEngine.Events;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class GronknoliusAppleEater : MonoBehaviour
    {
        #region Variables

        [SerializeField] private UnityEvent OnGronknoliusEatApple = new UnityEvent();

        #endregion

        #region Methods

        private void EatApple(GameObject apple)
        {
            if (apple.CompareTag("Apple"))
            {
                OnGronknoliusEatApple.Invoke();
                Destroy(apple);
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