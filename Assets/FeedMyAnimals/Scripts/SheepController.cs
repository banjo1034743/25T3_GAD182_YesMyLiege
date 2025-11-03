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

        [Header("Debug")]

        [Tooltip("Enable this to true to make the sheep continue forward toward _firstPositionToMoveTo. Set to false to make the sheep turn around and move to _secondPositionToMoveTo.")]
        [SerializeField] private bool _forceReturnValueForPlayerInBounds;

        #endregion

        #region Methods

        public void ExitPen()
        {

        }

        protected override void MoveInPattern()
        {
            switch (_firstPositionToMoveTo.magnitude)
            {
                case > 0:
                    // Call GroundCollider.GetCollider.bounds.Contains(transform.position)
                    if (_forceReturnValueForPlayerInBounds)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, _firstPositionToMoveTo, 0);
                    }
                    break;
                case <= 0:
                    break;
            }
        }



        private void DefineMovingRange()
        {
            _firstPositionToMoveTo = new Vector3(transform.position.x, transform.position.y, transform.position.z + _animalMovingBounds);
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