using TMPro;
using UnityEngine;

public class UICanvasStart : MonoBehaviour
{
    private TextMeshProUGUI textMesh => GetComponent<TextMeshProUGUI>();

    private void Start()
    {
        textMesh.text = $"Pick the gun and shoot the target to start.\r\n" +
            $"Reload putting the gun down.\r\n" +
            $"You have {GameCountDown.instance._maxTime} seconds.\r\n" +
            $"Good Luck!!";
    }
}