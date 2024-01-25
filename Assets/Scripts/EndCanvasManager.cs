using UnityEngine;

public class EndCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject canvasElements;
    private void Start()
    {
        GameManagerStatus.statusEvent.AddListener(EnableEndCanvas);
    }

    private void EnableEndCanvas(GameState state)
    {
        canvasElements.SetActive(state == GameState.Ended);
    }
}