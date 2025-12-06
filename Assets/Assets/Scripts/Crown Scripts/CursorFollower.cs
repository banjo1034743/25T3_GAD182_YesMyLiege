using UnityEngine;
using UnityEngine.InputSystem;

namespace DirtPoorPeasants.CutTheWheat
{
    /// <summary>
    /// This class is what is responsible for making objects follow the cursor
    /// </summary>
    public class CursorFollower : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("Enter how far away you want the object from the screen here.")]
        // This value affects the Z position of the object, moving it
        // further away from the screen or further in.
        [SerializeField] private float _distanceFromScreen;

        [Header("Objects")]

        [Tooltip("Place the object you want to follow the cursor here")]
        [SerializeField] private GameObject _objectFollowingCursor;

        [Header("Components")]

        [Tooltip("Place the camera used in the scene here.")]
        // Used for getting the mouses position usiing ScreenToWorldPosition
        [SerializeField] private Camera _camera;

        [Header("Input")]

        // We reference this to use for ensuring we get the correct action
        // when initializing _moveAction.
        private InputActionMap _cutTheWheatActionMap;

        // The reference to the input action for moving the sycthe.
        // We have a reference for reading the position of the mouse
        // to apply to our object
        private InputAction _moveAction;

        #endregion

        #region Methods

        private Vector3 GetMousePosition()
        {
            if (_moveAction != null)
            {
                Vector3 readValue = new Vector3(_moveAction.ReadValue<Vector2>().x, _moveAction.ReadValue<Vector2>().y, _distanceFromScreen);
                Debug.Log(_camera.ScreenToWorldPoint(readValue));

                // Screenspace and world space have very different ways of marking locations of objs,
                // so we need to convert it for this to work.
                return _camera.ScreenToWorldPoint(readValue);
            }
            else
            {
                // Need to return something for another condition, otherwise Unity will become angry
                return Vector3.zero;
            }
        }

        private void SetObjectToMouse()
        {
            _objectFollowingCursor.transform.position = GetMousePosition();
        }

        private void InitializeScript()
        {
            // Replace these with whatever action map and input action you're using
            _cutTheWheatActionMap = InputSystem.actions.FindActionMap("Microgame/CutTheWheat");
            _moveAction = _cutTheWheatActionMap.FindAction("Move");
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitializeScript();
        }

        // Update is called once per frame
        void Update()
        {
            SetObjectToMouse();
        }

        #endregion
    }
}