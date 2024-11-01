using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEnum : MonoBehaviour
{
    public Type interactType;

   public void SetEnum(Type type)
    {
        interactType = type;
    }
}

public enum Type
{
    None,
    Teleport,
    Construct
}