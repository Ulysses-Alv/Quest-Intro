using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform muzzlePosition;
    [SerializeField] private float appliedForce;

    private Vector3 finalForce => appliedForce * muzzlePosition.forward;
    private DrawLine drawLine => GetComponent<DrawLine>();


    public void Shoot()
    {
        var bullet = BulletPool.instance.GetBullet();
        SetBulletPosition(bullet);
        AddForce(bullet);
        BulletPool.instance.Eliminate(bullet);
    }
    private void Update()
    {
        DrawTrajectory();
    }
    private void DrawTrajectory()
    {
        drawLine.DrawTrajectory(muzzlePosition.position, finalForce);
    }
    private void SetBulletPosition(GameObject bullet)
    {
        bullet.transform.position = muzzlePosition.transform.position;
        bullet.transform.rotation = muzzlePosition.transform.rotation;
    }

    private void AddForce(GameObject bullet)
    {
        bullet.GetComponent<Rigidbody>().velocity = finalForce;
    }
}

