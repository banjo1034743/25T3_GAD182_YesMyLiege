using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    /// <summary>
    /// This is the base class for SheepController and GronknoliusController.
    /// They inherit their methods from here.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public abstract class AnimalController : MonoBehaviour
    {
        #region Variables

        [Tooltip("Use this to determine how fast the animal will travel to differnt points in the scene")]
        [SerializeField] protected float _animalMovementSpeed;

        [Tooltip("Determines the range in which the animal will pace around in")]
        [SerializeField] protected float _animalMovingBounds;

        protected Animator _animalAnimator;

        #endregion

        #region Methods

        protected abstract void MoveInPattern();

        protected abstract void Rotate(float amountToRotateBy);

        /// <summary>
        /// Put any components we need a reference to later in here
        /// so they can be ready for then. We also ensure that we
        /// grab the animator that was crfeated if there wasnt one
        /// already
        /// </summary>
        protected void InitializeScript()
        {
            if (_animalAnimator == null)
            {
                _animalAnimator = GetComponent<Animator>();
            }
        }

        #endregion
    }
}