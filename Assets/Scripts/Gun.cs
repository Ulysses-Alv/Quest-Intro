using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    [SerializeField] private Transform muzzlePosition;
    [SerializeField] private float appliedForce;
    [SerializeField] private int bulletsRemaining = 20;

    public int _bulletsRemaining => bulletsRemaining;

    private Vector3 finalForce => appliedForce * muzzlePosition.forward;

    [SerializeField] private UnityEvent InitializeGunEvent;
    [SerializeField] private UnityEvent DesactivateGunEvent;
    
    public CanShootEvent ShootGunEvent;

    
    public void TryShoot()
    {
        if (bulletsRemaining <= 0)
        {
            ShootGunEvent.Invoke(false);
            return;
        }
        Shoot();
    }


    private void Shoot()
    {
        bulletsRemaining--;

        GameObject bullet = BulletPool.instance.GetBullet();
        SetBullet(bullet);
        BulletPool.instance.Eliminate(bullet);
        UpdateText();

        ShootGunEvent.Invoke(true);
    }

    private void UpdateText()
    {
        BulletUIManager.instance.UpdateText(bulletsRemaining);
    }

    
    private void SetBullet(GameObject bullet)
    {
        bullet.transform.SetPositionAndRotation(muzzlePosition.transform.position, muzzlePosition.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = finalForce;
    }
   

    public void Recharge()
    {
        bulletsRemaining = 20;
        UpdateText();
    }

    public void InitializeGun()
    {
        InitializeGunEvent.Invoke();
    }
    public void DesactivateGun()
    {
        DesactivateGunEvent.Invoke();
    }
}

[System.Serializable]
public class CanShootEvent : UnityEvent<bool>
{

}