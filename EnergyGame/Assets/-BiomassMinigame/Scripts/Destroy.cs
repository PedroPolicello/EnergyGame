using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float animDuration;
    [SerializeField] private float punchPos;
    void Start()
    {
        Destroy(gameObject, duration);
    }
}
