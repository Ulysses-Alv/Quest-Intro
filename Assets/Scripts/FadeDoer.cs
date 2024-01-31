using UnityEngine;

public class FadeDoer : MonoBehaviour
{
    void Start()
    {
        FadeController.instance.DoFadeIn();
    }
}
