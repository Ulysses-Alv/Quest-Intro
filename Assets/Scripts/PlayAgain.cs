using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;

        GameManagerStatus.ChangeCurrentStatus(GameState.Playing);
        ScoreManager.Instance.RestartScore();
    }
}
