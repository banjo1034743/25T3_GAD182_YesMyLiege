using System.Collections;
using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class SheepController : AnimalController
    {
        #region Variables

        [Header("Data")]

        [Tooltip("Determines the range in which the sheep will pace around in")]
        [SerializeField] private float _animalMovingBounds;

        [Tooltip("Enter the position where the sheep is no longer on screen.")]
        [SerializeField] private Vector3 _positionToExitTo;

        private Coroutine _exitPenCoroutine;

        [Header("Components")]

        [SerializeField] private Collider _gameArea;

        [Header("Scripts")]

        // We use this for updating the speed when we exit the pen as a sheep
        [SerializeField] private GronknoliusController _gronknoliusController;

        // We reference this to get access to the PlaySFX() method.
        [SerializeField] private SheepSoundPlayer _sheepSoundPlayer;

        [SerializeField] private SheepManager _sheepManager;

        [SerializeField] private SheepAppleEater _sheepAppleEater;

        #endregion

        #region Methods
        
        public void BeginExitPenCoroutine()
        {
            if (_exitPenCoroutine == null)
            {
                _exitPenCoroutine = StartCoroutine(ExitPen());
            }
        }

        private IEnumerator ExitPen()
        {
            // So the sheep is facing the right way when exiting
            if (_movingDirection == MovingDirectionEnum.movingToFirst)
            {
                Rotate(-180);
            }

            while (transform.position.x > _positionToExitTo.x)
            {
                transform.position = Vector3.MoveTowards(transform.position, _positionToExitTo, 4f * _animalMovementSpeed * Time.deltaTime);
                Debug.Log("We're currently in the ExitPen() while loop");

                yield return null;
            }

            _sheepSoundPlayer.PlayClipAt(0, transform.position, 0.5f);

            _gronknoliusController.IncreaseMovementSpeed();

            _sheepManager.RemoveSheep(gameObject);
        }

        private void DefineMovingRange()
        {
            // As Vector3.MoveTowards does not take into account the local rotation
            // of the sheep, we're moving on the X to move sideways rather than
            // in it's forward direction of Z. Probably not the best implementation
            // but I know we're only going to move this on one axis so it shouldn;t
            // matter that much.
            _firstPositionToMoveTo = new Vector3(transform.position.x + _animalMovingBounds, transform.position.y, transform.position.z);
            _secondPositionToMoveTo = new Vector3(transform.position.x - _animalMovingBounds, transform.position.y, transform.position.z);
        }

        protected override void MoveInPattern()
        {
            if (!_sheepAppleEater.GetHasEatenApple() && !GameManager.instance.GetGameOverValue())
            {
                Debug.Log("Despite having eten the apple, we're still calling MoveInPattern()");
                base.MoveInPattern();
            }
        }

        protected override void MoveToPosition(Vector3 vectorToMoveOn)
        {
            if (!_sheepAppleEater.GetHasEatenApple())
            {
                base.MoveToPosition(vectorToMoveOn);
            }
        }

        protected override void Rotate(float amountToRotateBy)
        {
            base.Rotate(amountToRotateBy);
        }

        protected override void InitializeAnimal()
        {
            base.InitializeAnimal();

            DefineMovingRange();

            if (_movingDirection == MovingDirectionEnum.movingToFirst)
            {
                // We do not call rotate for this as we're assummung that
                // the sheep will be default be facing in this direction
                ReadustPositon();
            }
            else if (_movingDirection == MovingDirectionEnum.movingToSecond)
            {
                Rotate(180);
                ReadustPositon();
            }

        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected void Start()
        {
            InitializeAnimal();
        }

        // Update is called once per frame
        protected void Update()
        {
            MoveInPattern();
        }

        #endregion
    }
}