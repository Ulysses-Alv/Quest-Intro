using TMPro;
using UnityEngine;

public class UICountDownManager : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro => GetComponent<TextMeshProUGUI>();

    private void Update()
    {
        UpdateTextUI();
    }

    private void UpdateTextUI()
    {
        float time = GameCountDown.instance._countDown;

        int seconds = (int)time % 60;
        int miles = (int)((time * 1000) % 1000);

        string _miles = "<size=" + textMeshPro.fontSize / 2 + ">" + miles.ToString("000") + "</size>";
        
        textMeshPro.text = $"Time: {seconds}:{_miles}";
    }
}