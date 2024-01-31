using UnityEngine;

public class ScoreCanvasController : MonoBehaviour
{
    GameObject canvasGO => gameObject.transform.GetChild(0).gameObject;
    void Start()
    {
        GameManagerStatus.statusEvent.AddListener(EnableText);
    }

    private void EnableText(GameState status)
    {
        canvasGO.SetActive(status == GameState.Playing);
    }
}
