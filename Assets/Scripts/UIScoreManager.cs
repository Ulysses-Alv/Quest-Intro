using TMPro;
using UnityEngine;

public class UIScoreManager : MonoBehaviour
{
    private TextMeshProUGUI text => GetComponent<TextMeshProUGUI>();

    public static UIScoreManager Instance;
    private int currentScore;

    private void Awake()
    {
        Instance = this;
        currentScore = 0;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        UpdateScore();
    }

    private void UpdateScore()
    {
        text.text = $"Score: {currentScore}";
    }
}