using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

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

    #endregion

    #region Methods

    private Vector3 GetMousePosition()
    {
        return _camera.ScreenToWorldPoint(Mouse.current.position);
    }

    private void SetObjectToMouse()
    {

    }

    #endregion

    #region Unity Methods

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}