using UnityEngine;
using UnityEngine.Serialization;

public class InteractEnum : MonoBehaviour
{
    [HideInInspector] public InteractType interactType;

    public void SetEnum(InteractType newType)
    {
        interactType = newType;
    }
}

public enum InteractType
{
    None,
    Teleport,
    Construct,
    BiomassGenerator
}