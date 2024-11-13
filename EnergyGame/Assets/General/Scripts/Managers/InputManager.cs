using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private InputControls inputControls;

    public Vector2 Move => inputControls.Player.Movement.ReadValue<Vector2>();

    public InteractType near;

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
            case InteractType.BiomassMinigame:
                GameManager.Instance.minigameController.BiomassMinigame(true);
                ResetInteract();
                break;

            case InteractType.BiomassGenerator:
                GameManager.Instance.biomassGenerator.AddEnergy(GameManager.Instance.playerControl.fuelAmount);
                GameManager.Instance.playerControl.ResetFuel();
                ResetInteract();
                break;
            
            case InteractType.HidricMinigame:
                print("starting hidric minigame...");
                break;

            case InteractType.HidricGenerator:
                print("rotating Pipes..."); 
                break;
            
            default:
                break;
        }
    }

    void ResetInteract()
    {
        GameManager.Instance.interactEnum.principalInteractType = InteractType.None;
    }

    public void EnableMovement() => inputControls.Player.Movement.Enable();
    public void DisableMovement() => inputControls.Player.Movement.Disable();
}
