using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

/// <summary>
/// This class is what is responsible for making objects follow the cursor
/// </summary>
public class CursorFollower : MonoBehaviour
{
    #region Variables

    [Header("Objects")]

    [Tooltip("Place the object you want to follow the cursor here")]
    [SerializeField] private GameObject _objectFollowingCursor;

    [Header("Components")]

    [Tooltip("Place the camera used in the scene here.")]
    // Used for getting the mouses position usiing ScreenToWorldPosition
    [SerializeField] private Camera _camera;

    [Header("Input")]

    [Tooltip("Place the action map with your input actions for the microgame here.")]
    // We reference this to use for ensuring we get the correct action
    // when initializing _moveAction.
    private InputActionMap _cutTheWheatActionMap;

    [Tooltip("Place the input action for moving (usually mouse position) here")]
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
            //Debug.Log("_moveAction is not null!");
            Debug.Log(_moveAction.activeControl);
            Vector2 readValue = _camera.ScreenToWorldPoint(_moveAction.ReadValue<Vector2>());
            return new Vector3(readValue.x, readValue.y, 10);
        }
        else
        {
            return Vector3.zero;
        }
    }

    private void SetObjectToMouse()
    {
        _objectFollowingCursor.transform.position = GetMousePosition();
    }

    private void InitializeInputActions()
    {
        _cutTheWheatActionMap = InputSystem.actions.FindActionMap("Microgame/CutTheWheat");
        _moveAction = _cutTheWheatActionMap.FindAction("Move");
    }

    #endregion

    #region Unity Methods

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeInputActions();
    }

    // Update is called once per frame
    void Update()
    {
        SetObjectToMouse();
    }

    #endregion
}