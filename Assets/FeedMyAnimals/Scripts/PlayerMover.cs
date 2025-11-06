using UnityEngine;
using UnityEngine.InputSystem;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class PlayerMover : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("This will be initialized when the game starts")]
        [SerializeField] private float _playerMovingBounds;

        [Header("Scripts")]

        [SerializeField] private GroundCollider _groundCollider;

        private InputActionMap _feedMyAnimalsActionMap;

        private InputAction _moveAction;

        #endregion

        #region Methods

        private void MovePlayer()
        {
            if (transform.position.x < _playerMovingBounds && transform.position.x > -_playerMovingBounds)
            {
                transform.position = new Vector3(_moveAction.ReadValue<float>(), transform.position.y, transform.position.z);
            }
        }

        private void InitializePlayer()
        {
            _feedMyAnimalsActionMap = InputSystem.actions.FindActionMap("Microgame/FeedMyAnimals");
            _moveAction = _feedMyAnimalsActionMap.FindAction("Move");

            _playerMovingBounds = _groundCollider.GetGroundColliderBoundsSize().x;
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitializePlayer();
        }

        // Update is called once per frame
        void Update()
        {
            MovePlayer();
        }

        #endregion
    }
}