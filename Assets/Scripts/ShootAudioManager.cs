using UnityEngine;

public class ShootAudioManager : MonoBehaviour
{
    private AudioSource audioSource => GetComponent<AudioSource>();

    [SerializeField] private AudioClip canShootClip;
    [SerializeField] private AudioClip cantShootClip;

    private Gun gun => GetComponentInParent<Gun>();

    private void Start()
    {
        gun.ShootGunEvent.AddListener(PlaySound);
    }

    private void PlaySound(bool canShoot)
    {
        audioSource.clip = canShoot ? 
            canShootClip : cantShootClip;
        
        audioSource.Play();
    }
}