using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Color color;
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }
}
