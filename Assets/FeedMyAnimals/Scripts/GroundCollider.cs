using System.Diagnostics.Contracts;
using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class GroundCollider : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Collider thisCollider;

        #endregion

        #region Methods

        public Vector3 GetGroundColliderBoundsSize()
        {
            return thisCollider.bounds.size;
        }

        public Vector3 GetGroundColliderBoundsCentre()
        {
            return thisCollider.bounds.center;
        }

        public Collider GetCollider()
        {
            return thisCollider;
        }

        private void DestroyApple(GameObject apple)
        {
            if (apple.CompareTag("Apple"))
            {
                Destroy(apple);
            }
        }

        #endregion

        #region Unity Methods

        private void OnTriggerEnter(Collider other)
        {
            DestroyApple(other.gameObject);
        }

        #endregion
    }
}