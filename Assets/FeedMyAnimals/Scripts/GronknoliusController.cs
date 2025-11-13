using UnityEngine;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class GronknoliusController : AnimalController
    {
        #region Variables

        [Header("Data")]

        [Tooltip("Adjust this to increase how much Gronknolius' speed will increase everytime a sheep is fed an apple.")]
        [SerializeField] private float _amountToIncrementSpeedBy;

        [Header("Scripts")]

        //The script that is used to play sound effects that we reference for this.
        [SerializeField] private GronknoliusSoundPlayer _gronknoliusSoundPlayer;

        #endregion

        #region Methods

        public void IncreaseMovementSpeed()
        {
            _animalMovementSpeed += _amountToIncrementSpeedBy;
            _gronknoliusSoundPlayer.PlaySFX(0, transform.position);
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

        protected override void InitializeAnimal()
        {
            base.InitializeAnimal();
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitializeAnimal();  
        }

        // Update is called once per frame
        void Update()
        {
            MoveInPattern();
        }

        #endregion
    }
}