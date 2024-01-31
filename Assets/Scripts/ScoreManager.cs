using System;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int currentScore;
    public int _currentScore => currentScore;

    private int recordScore;

    [HideInInspector] public UnityEvent<int> updateScoreEvent;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        updateScoreEvent = new UnityEvent<int>();
        currentScore = 0;
    }
    public int GetRecordScore()
    {
        recordScore = PlayerPrefs.GetInt("Record", 0);

        return recordScore;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        currentScore = Mathf.Max(0, currentScore);
        updateScoreEvent.Invoke(currentScore);
    }

    public void RestartScore()
    {
        currentScore = 0;
        updateScoreEvent.Invoke(currentScore);
    }
}