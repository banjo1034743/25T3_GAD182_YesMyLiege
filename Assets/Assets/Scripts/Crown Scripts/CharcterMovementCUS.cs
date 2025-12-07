using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CharcterMovementCUS : MonoBehaviour
{
[SerializeField] private InputActionAsset inputActionAssets;
private InputActionMap cleanUpStablesActions;
private InputAction inputActionR;
private InputAction inputActionL;
private float playerSpeed = 100f;


    void Start()
    {
        cleanUpStablesActions = inputActionAssets.FindActionMap("Microgame/CleanUpStables");
        inputActionR = cleanUpStablesActions.FindAction("MovementR");
        inputActionL = cleanUpStablesActions.FindAction("MovementL");
    }
    void Update()
    {
        if (inputActionR.WasPerformedThisFrame() == true)
        {
            transform.Translate(1f,0,0);
        }

        else if (inputActionL.WasPerformedThisFrame() == true)
        {
            transform.Translate(-1f,0,0);
        }
    }
}
