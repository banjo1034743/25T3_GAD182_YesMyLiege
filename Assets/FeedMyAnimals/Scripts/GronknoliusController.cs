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
            _gronknoliusSoundPlayer.PlayClipAt(0, transform.position, 0.5f);
        }

        protected override void MoveInPattern()
        {
            if (!GameManager.instance.GetGameOverValue())
            {
                base.MoveInPattern();
            }
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

        bool ColliderContainsPoint(Transform ColliderTransform, Vector3 Point, bool Enabled)
        {
            Vector3 localPos = ColliderTransform.InverseTransformPoint(Point);
            if (Enabled && Mathf.Abs(localPos.x) < 0.5f && Mathf.Abs(localPos.y) < 0.5f && Mathf.Abs(localPos.z) < 0.5f)
                return true;
            else
                return false;
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