using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Generator", menuName = "ScriptableObjects/New Generator")]
public class SO_Generator : ScriptableObject
{
    public GeneratorType generator;
    public float timeToEnergy;
    public Sprite sprite;
}

public enum GeneratorType
{
    Solar,
    Hidrico,
    Eolico
}
