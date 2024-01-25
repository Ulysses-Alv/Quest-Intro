using UnityEngine;

public class GameSartSetUp : MonoBehaviour
{
    private void Awake()
    {
        GameManagerStatus.Initialize();
    }
}