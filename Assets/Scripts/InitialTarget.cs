using UnityEngine;

public class InitialTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;

        GameManagerStatus.ChangeCurrentStatus(GameState.Playing);
        DeleteTarget();
    }
    private void DeleteTarget()
    {
        gameObject.SetActive(false);
    }
}
