using UnityEngine;

public class FadeController : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>();

    public static FadeController instance;

    private void Awake()
    {
        instance = this;
    }

    public void DoFadeOut()
    {
        animator.SetTrigger("FadeOut");
    }

    public void DoFadeIn()
    {
        animator.SetTrigger("FadeIn");
    }
}