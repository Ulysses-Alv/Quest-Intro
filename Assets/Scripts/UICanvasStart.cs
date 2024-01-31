using TMPro;
using UnityEngine;

public class UICanvasStart : MonoBehaviour
{
    private TextMeshProUGUI textMesh => GetComponent<TextMeshProUGUI>();

    private void Start()
    {
        textMesh.text = $"How to play " +
            $"Pick the gun and shoot the target to start.\r\n" +
            $"Reload putting the gun down.\r\n" +
            $"You have 60 seconds.\r\n" +
            $"Good Luck!!";
    }
}