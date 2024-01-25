using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIScoreManager : MonoBehaviour
{
    private TextMeshProUGUI text => GetComponent<TextMeshProUGUI>();

    public static UIScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ScoreManager.Instance.updateScoreEvent.AddListener((int currentScore) => { text.text = $"Score: {currentScore}"; });
    }
}
