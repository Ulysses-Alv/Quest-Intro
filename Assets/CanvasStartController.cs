using UnityEngine;

public class CanvasStartController : MonoBehaviour
{
    [SerializeField] private GameObject panelAndText;
    void Start()
    {
        GameManagerStatus.statusEvent.AddListener(ChangeStatusCanvas);
    }

    private void ChangeStatusCanvas(GameState state)
    {
        panelAndText.SetActive(state == GameState.Menu);
    }
}
