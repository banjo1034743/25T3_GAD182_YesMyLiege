using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class SheepController : AnimalController
    {
        #region Variables

        [Header("Data")]

        [Tooltip("Determines the range in which the sheep will pace around in")]
        [SerializeField] private float _animalMovingBounds;

        [Header("Scripts")]

        // We use this for updating the speed when we exit the pen as a sheep
        [SerializeField] private GronknoliusController _gronknoliusController;

        #endregion

        #region Methods

        public void ExitPen()
        {
            while (_animalWalkingZone.bounds.Contains(transform.position))
            {
                transform.Translate(1 * _animalMovementSpeed * Time.deltaTime, 0, 0);
            }

            // Call RemoveSheep(gameObject) in SheepManager

            // Call PlayAnimalSFX(0, transform.position) in SheepSoundManager

            _gronknoliusController.IncreaseMovementSpeed();
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