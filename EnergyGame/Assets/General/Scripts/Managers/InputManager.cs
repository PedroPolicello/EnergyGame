using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private InputControls inputControls;

    public Vector2 Move => inputControls.Player.Movement.ReadValue<Vector2>();

    [HideInInspector] public InteractType principalInteractType;
    [HideInInspector] public bool inPipe;

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
        switch (principalInteractType)
        {
            case InteractType.BiomassMinigame:
                if(!GameManager.Instance.minigameController.biomassFinished) GameManager.Instance.minigameController.BiomassMinigame(true);
                //print("starting biomass minigame..."); 
                break;

            case InteractType.BiomassGenerator:
                GameManager.Instance.biomassGenerator.AddEnergy(GameManager.Instance.playerControl.fuelAmount);
                GameManager.Instance.playerControl.ResetFuel();
                //print("adding fuel...");
                break;
            
            case InteractType.HidricMinigame:
                if (!GameManager.Instance.minigameController.hidricFinished) GameManager.Instance.minigameController.HidricMinigame(true);
                //print("starting hidric minigame...");
                break;

            case InteractType.HidricPipe:
                //DO NOTHING
                break;
            
            case InteractType.EolicMinigame:
                if (!GameManager.Instance.minigameController.eolicFinished) GameManager.Instance.minigameController.EolicMinigame(true);
                //print("starting eolic minigame..."); 
                break;
            
            case InteractType.EolicMill:
                //DO NOTHING
                break;
            
            case InteractType.Sell:
                GameManager.Instance.vendorManager.SellEnergy();
                //print("selling energy..."); 
                break;
            
            case InteractType.Buy:
                GameManager.Instance.vendorManager.BuyNextMinigame();
                //print("buying generator..."); 
                break;
            
            default:
                break;
        }

    }

    
    public void SetEnum(InteractType newType)
    {
        principalInteractType = newType;
    }

    public void EnableMovement() => inputControls.Player.Movement.Enable();
    public void DisableMovement() => inputControls.Player.Movement.Disable();
    
    public void EnableInteract() => inputControls.Player.Interact.Enable();
    public void DisableInteract() => inputControls.Player.Interact.Disable();
}
