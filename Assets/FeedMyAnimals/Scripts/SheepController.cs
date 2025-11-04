using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class SheepController : AnimalController
    {
        #region Variables

        [Header("Data")]

        [Tooltip("This will be updated automatically in the script as the sheep moves about")]
        [SerializeField] private Vector3 _firstPositionToMoveTo;

        [Tooltip("This will be updated automatically in the script as the sheep moves about")]
        [SerializeField] private Vector3 _secondPositionToMoveTo;

        private enum MovingDirectionEnum
        {
            movingToFirst,
            movingToSecond
        }

        [SerializeField] private MovingDirectionEnum _movingDirection;

        [Header("Debug")]

        [Tooltip("Enable this to true to make the sheep continue forward toward _firstPositionToMoveTo. Set to false to make the sheep turn around and move to _secondPositionToMoveTo.")]
        [SerializeField] private bool _forceReturnValueForPlayerInBounds;

        #endregion

        #region Methods

        /// <summary>
        /// DO NOT CALL THIS YET, will freeze Unity otherwise
        /// We call this to make the Sheep exit the pen.
        /// </summary>
        public void ExitPen()
        {
            // Call GroundCollider.GetCollider.bounds.Contains(transform.position)

            // Temporary condition for if while GroundCollider script hasnt
            // been coded yet. This will also freeze Unity if this is played
            // as it is so please do not call it yet.
            while (_forceReturnValueForPlayerInBounds)
            {
                transform.Translate(1 * _animalMovementSpeed * Time.deltaTime, 0, 0);
            }

            // Call RemoveSheep(gameObject) in SheepManager

            // Call PlayAnimalSFX(0, transform.position) in SheepSoundManager

            // Call IncreaseMovementSpeed in GronknoliusController
        }

        protected override void MoveInPattern()
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

        private void MoveToPosition(Vector3 vectorToMoveOn)
        {
            switch (Vector3.Distance(transform.position, vectorToMoveOn))
            {
                case > 0:
                    // Call GroundCollider.GetCollider.bounds.Contains(transform.position)

                    // Temporary condition for if while GroundCollider script
                    // hasnt been coded yet
                    if (_forceReturnValueForPlayerInBounds) 
                    {
                        transform.position = Vector3.MoveTowards(transform.position, vectorToMoveOn, _animalMovementSpeed * Time.deltaTime);
                    }
                    else
                    {
                        Rotate(180);
                    }
                    break;
                case <= 0:
                    Debug.Log("The distane between us and [" + vectorToMoveOn + "] is 0");
                    Rotate(180);
                    if (_movingDirection == MovingDirectionEnum.movingToFirst)
                    {
                        _movingDirection = MovingDirectionEnum.movingToSecond;
                    }
                    else
                    {
                        _movingDirection = MovingDirectionEnum.movingToFirst;
                    }
                    break;
            }
        }

        protected override void Rotate(float amountToRotateBy)
        {
            transform.Rotate(0, amountToRotateBy, 0);
        }

        private void DefineMovingRange()
        {
            // As Vector3.MoveTowards does not take into account the local rotation
            // of the sheep, we're moving on the X to move sideways rather than
            // in it's forward direction of Z. Probably not the best implementation
            // but I know we're only going to move this on one axis so it shouldn;t
            // matter that much.
            _firstPositionToMoveTo = new Vector3(transform.position.x + _animalMovingBounds, transform.position.y, transform.position.z);
            _secondPositionToMoveTo = transform.position;
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitializeScript();
            DefineMovingRange();
        }

        // Update is called once per frame
        void Update()
        {
            MoveInPattern();
        }

        #endregion
    }
}