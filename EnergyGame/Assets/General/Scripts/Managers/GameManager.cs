using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    [Header("Managers")]
    public PlayerControl playerControl;
    public InteractEnum interactable;
    public UIManager uiManager;

    [Header("Generators")]
    public BiomassGenerator biomassGenerator;

    void Awake()
    {
        Instance = this;
        InputManager = new InputManager();
    }
}
