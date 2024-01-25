using UnityEngine;

public class TargetAudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip hitted, missed;
    private AudioSource audioSource => GetComponent<AudioSource>();

    public static TargetAudioManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void TargetHitted()
    {
        audioSource.clip = hitted;
        audioSource.Play();
    }

    public void TargetMissed()
    {
        audioSource.clip = missed;
        audioSource.Play();
    }
}
