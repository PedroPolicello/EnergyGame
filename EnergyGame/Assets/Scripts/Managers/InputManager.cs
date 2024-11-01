using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private InputControls inputControls;

    public Vector2 Move => inputControls.Player.Movement.ReadValue<Vector2>();

    public Type near;

    public InputManager()
    {
        Instance = this;
        inputControls = new InputControls();
        inputControls.Enable();

        inputControls.Player.Interact.performed += OnInteractPerformed;
        inputControls.Player.Pause.performed += OnPauseGamePerformed;
    }

    private void OnPauseGamePerformed(InputAction.CallbackContext obj)
    {

    }

    private void OnInteractPerformed(InputAction.CallbackContext obj)
    {
        switch (near)
        {
            case Type.Teleport:
                print("teleporting...");
                break;

            case Type.Construct:
                print("constructing..."); 
                break;

            default:
                break;
        }
    }

    public void EnableMovement() => inputControls.Player.Movement.Enable();
    public void DisableMovement() => inputControls.Player.Movement.Disable();
}
