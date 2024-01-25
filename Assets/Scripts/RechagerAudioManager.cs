using UnityEngine;

public class RechagerAudioManager : MonoBehaviour
{
    public static RechagerAudioManager instance;

    [SerializeField] private AudioClip rechargeClip;
    private AudioSource audioSource => GetComponent<AudioSource>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        audioSource.clip = rechargeClip;
    }
    public void RechargePlay()
    {
        audioSource.Play();
    }
}


//piso (322.01, 56.14, 359.57)
//vista de ojos (322.74, 18.76, 22.28)
//cielo (287.68, 32.58, 332.63)