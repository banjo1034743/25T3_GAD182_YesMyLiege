using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class SheepController : AnimalController
    {
        #region Variables

        [Header("Data")]

        [Tooltip("Determines the range in which the sheep will pace around in")]
        [SerializeField] private float _animalMovingBounds;

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
            while (_groundCollider.GetCollider().bounds.Contains(transform.position))
            {
                transform.Translate(1 * _animalMovementSpeed * Time.deltaTime, 0, 0);
            }

            // Call RemoveSheep(gameObject) in SheepManager

            // Call PlayAnimalSFX(0, transform.position) in SheepSoundManager

            // Call IncreaseMovementSpeed in GronknoliusController
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

        protected override void MoveInPattern()
        {
            base.MoveInPattern();
        }

        protected override void MoveToPosition(Vector3 vectorToMoveOn)
        {
            base.MoveToPosition(vectorToMoveOn);
        }

        protected override void Rotate(float amountToRotateBy)
        {
            base.Rotate(amountToRotateBy);
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitializeAnimal();
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