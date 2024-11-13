using UnityEngine;
using UnityEngine.Serialization;

public class InteractEnum : MonoBehaviour
{
    [HideInInspector] public InteractType principalInteractType;

    public void SetEnum(InteractType newType)
    {
        principalInteractType = newType;
    }
}

public enum InteractType
{
    None,
    BiomassMinigame,
    HidricMinigame,
    BiomassGenerator,
    HidricGenerator
}