using UnityEngine.Events;

public static class GameManagerStatus
{
    private static GameState currentStatus;

    public static UnityEvent<GameState> statusEvent;

    public static bool IsMenu()
    {
        return currentStatus.Equals(GameState.Menu);
    }
    public static bool IsPlaying()
    {
        return currentStatus.Equals(GameState.Playing);
    }
    
    public static bool IsEnded()
    {
        return currentStatus.Equals(GameState.Ended);
    }

    public static void Initialize()
    {
        if(statusEvent == null)
        {
            statusEvent = new UnityEvent<GameState>();
        }
        ChangeCurrentStatus(GameState.Menu);
    }

    public static void ChangeCurrentStatus(GameState gameStatus) 
    {
        currentStatus = gameStatus;
        statusEvent.Invoke(currentStatus);
    }
}

public enum GameState
{
    Menu, Playing, Ended
}
