using System;
using TMPro;
using UnityEngine;

public class WristCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject canvasWrist;
    private void Awake()
    {
        canvasWrist.SetActive(false);
    }
    public void EnableCanvasWrist(GameObject wristGO)
    {
        canvasWrist.SetActive(true);

        canvasWrist.transform.parent = wristGO.transform;
        canvasWrist.transform.position = wristGO.transform.position;
        canvasWrist.transform.rotation = wristGO.transform.rotation;
    }
    public void DisableCanvasWrist()
    {
        canvasWrist.transform.parent = null;
        canvasWrist.SetActive(true);
    }
}
