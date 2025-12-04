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

        [SerializeField] private Vector2 _lastRecordedMousePosition;

        [Header("Components")]

        [SerializeField] private Camera _mainCamera;

        [SerializeField] private InputActionAsset _actions;

        [Header("Scripts")]

        [SerializeField] private GroundCollider _groundCollider;

        [SerializeField] private PlayerAnimationToggler _playerAnimationToggler;

        private InputActionMap _feedMyAnimalsActionMap;

        private InputAction _moveAction;

        #endregion

        #region Methods

        /// <summary>
        /// This method is called by PlayerAnimationToggler to know when the
        /// player is moving so it can play the shuffling animation
        /// </summary>
        /// <returns></returns>
        public void CheckIsMoving()
        {
            Vector2 differenceToCalculate = _moveAction.ReadValue<Vector2>() - _lastRecordedMousePosition;

            if (differenceToCalculate.magnitude > 0.01f)
            {
                _playerAnimationToggler.ToggleMoveAnimation(true);
            }
            else
            {
                _playerAnimationToggler.ToggleMoveAnimation(false);
            }

            _lastRecordedMousePosition = _moveAction.ReadValue<Vector2>();
        }

        private void MovePlayer()
        {
            if (!GameManager.instance.GetGameOverValue())
            {
                if (transform.position.x < _playerMovingBounds && transform.position.x > -_playerMovingBounds)
                {
                    // 10 is what keeps the player directly over the highet ground in screenspace
                    Vector3 readValue = new Vector3(_moveAction.ReadValue<Vector2>().x, _moveAction.ReadValue<Vector2>().y, 10);

                    // readValue doesn't translate over to worldspace yet, so we need to convert it
                    Vector3 screenPosition = _mainCamera.ScreenToWorldPoint(readValue);

                    // 1 is what keeps the player directly over the highet ground in world space
                    transform.position = new Vector3(screenPosition.x, transform.position.y, 1);
                }
                // These else conditions ensure we are kept in the bounds and ensure we dont get stuck out of them by
                // moving us slightly out
                else if (transform.position.x > _playerMovingBounds)
                {
                    transform.position = new Vector3(_playerMovingBounds - 0.1f, transform.position.y, 1);
                }
                else if (transform.position.x < -_playerMovingBounds)
                {
                    transform.position = new Vector3(-_playerMovingBounds + 0.1f, transform.position.y, 1);
                }
            }
        }

        private void InitializePlayer()
        {
            _feedMyAnimalsActionMap = _actions.FindActionMap("Microgame/FeedMyAnimals");
            _moveAction = _feedMyAnimalsActionMap.FindAction("Move");

            _mainCamera = Camera.main;

            _playerMovingBounds = _groundCollider.GetGroundColliderBoundsSize().x / 2;

            // get current position as of now prioer to moving
            _lastRecordedMousePosition = _moveAction.ReadValue<Vector2>();
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
            CheckIsMoving();
        }

        #endregion
    }
}