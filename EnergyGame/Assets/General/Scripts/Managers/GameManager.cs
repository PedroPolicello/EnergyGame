using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    [Header("Managers")]
    public PlayerControl playerControl;
    public UIManager uiManager;
    public MinigameController minigameController;
    public VendorManager vendorManager;

    [Header("Biomass Generators")]
    public BiomassGenerator biomassGenerator;

    void Awake()
    {
        Instance = this;
        InputManager = new InputManager();
    }
}
