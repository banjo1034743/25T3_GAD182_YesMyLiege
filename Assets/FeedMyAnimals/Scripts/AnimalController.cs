using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    /// <summary>
    /// This is the base class for SheepController and GronknoliusController.
    /// They inherit their methods from here.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class AnimalController : MonoBehaviour
    {
        #region Variables

        [Header("Data (Animal Controller)")]

        [Tooltip("Use this to determine how fast the animal will travel to differnt points in the scene")]
        [SerializeField] protected float _animalMovementSpeed;

        [Tooltip("For the sheep, this will be updated automatically in the script as the sheep moves about")]
        [SerializeField] protected Vector3 _firstPositionToMoveTo;

        [Tooltip("For the sheep, this will be updated automatically in the script as the sheep moves about")]
        [SerializeField] protected Vector3 _secondPositionToMoveTo;

        [Tooltip("Sets the Y value of animals to this. Should be set to whatever looks best. Currently 3.")]
        [SerializeField] protected float _heightToStartAt;
        protected enum MovingDirectionEnum
        {
            movingToFirst,
            movingToSecond
        }

        [SerializeField] protected MovingDirectionEnum _movingDirection;

        [Header("Components (AnimalController")]

        [SerializeField] protected Animator _animalAnimator;

        [Tooltip("Drop the collider that expands out as far as you want the animals to walk in here")]
        [SerializeField] protected Collider _animalWalkingZone;

        #endregion

        #region Methods

        protected virtual void MoveInPattern()
        {
            if (_movingDirection == MovingDirectionEnum.movingToFirst)
            {
                Debug.Log("Called MoveToPositon for _firstPositionToMoveTo");
                _movingDirection = MovingDirectionEnum.movingToFirst;
                MoveToPosition(_firstPositionToMoveTo);
            }
            else if (_movingDirection == MovingDirectionEnum.movingToSecond)
            {
                Debug.Log("Called MoveToPositon for _secondPositionToMoveTo");
                _movingDirection = MovingDirectionEnum.movingToSecond;
                MoveToPosition(_secondPositionToMoveTo);
            }
        }

        protected virtual void MoveToPosition(Vector3 vectorToMoveOn)
        {
            switch (Vector3.Distance(transform.position, vectorToMoveOn))
            {
                case > 0:
                    transform.position = Vector3.MoveTowards(transform.position, vectorToMoveOn, _animalMovementSpeed * Time.deltaTime);

                    if (_animalWalkingZone.bounds.Contains(transform.position) == false)
                    {
                        Rotate(180);
                        ChangeDirections();
                    }
                    break;
                case <= 0:
                    Debug.Log("The distane between us and [" + vectorToMoveOn + "] is 0");
                    Rotate(180);
                    ChangeDirections();
                    break;
                }
            }

        protected virtual void Rotate(float amountToRotateBy)
        {
            transform.Rotate(0, amountToRotateBy, 0);
        }

        /// <summary>
        /// If _movingDirection is movingToFirst, it will switch to movingToSecond
        /// and vice versa
        /// </summary>
        protected virtual void ChangeDirections()
        {
            if (_movingDirection == MovingDirectionEnum.movingToFirst)
            {
                ReadustPositon();

                _movingDirection = MovingDirectionEnum.movingToSecond;
            }
            else
            {
                ReadustPositon();

                _movingDirection = MovingDirectionEnum.movingToFirst;
            }
        }

        /// <summary>
        /// This method prevents a bug where the sheep will infinte
        /// spam Rotate() if the position their trying to reach is
        /// beyond the stage. It brings them back into the collider
        /// bounds regardless of which side they stand on
        /// </summary>
        protected void ReadustPositon()
        {
            if (transform.position.x >= 0)
            {
                transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < 0)
            {
                transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            }
        }

        /// <summary>
        /// Put any components we need a reference to later in here
        /// so they can be ready for then. We also ensure that we
        /// grab the animator that was crfeated if there wasnt one
        /// already
        /// </summary>
        protected virtual void InitializeAnimal()
        {
            if (_animalAnimator == null)
            {
                _animalAnimator = GetComponent<Animator>();
            }

            transform.position = new Vector3(transform.position.x, _heightToStartAt, transform.position.z);
        }

        #endregion
    }
}