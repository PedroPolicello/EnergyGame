using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    void Awake()
    {
        Instance = this;
        InputManager = new InputManager();
    }
}
