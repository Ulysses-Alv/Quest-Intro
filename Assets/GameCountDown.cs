using System;
using UnityEngine;

public class GameCountDown : MonoBehaviour
{
    [SerializeField, Range(10f, 240f)] private float maxTime;
    public float _maxTime => maxTime;

    private float countDown;

    public float _countDown => countDown;

    private Action coutdownAction;
    public static GameCountDown instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameManagerStatus.statusEvent.AddListener(ShouldStartCountDown);
    }

    private void ShouldStartCountDown(GameState state)
    {
        if (state != GameState.Playing)
        {
            StopCountdown();
            return;
        }

        StartCountdown();
    }

    private void Update()
    {
        coutdownAction?.Invoke();
    }

    private void Countdown()
    {
        countDown -= Time.deltaTime;

        if (countDown > 0) return;

        GameManagerStatus.ChangeCurrentStatus(GameState.Ended);
    }
    private void StartCountdown()
    {
        coutdownAction = Countdown;
        countDown = maxTime;
    }
    private void StopCountdown()
    {
        coutdownAction = null;
        countDown = maxTime;
    }
}
