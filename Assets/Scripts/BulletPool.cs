using ObjectPoolingPattern;
using System;
using System.Collections;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    public static BulletPool instance;

    WaitForSeconds wait;
    private void Awake()
    {
        instance = this;
        wait = new(5);
    }

    void Start()
    {
        ObjectPooling.PreLoad(bulletPrefab, 10);
    }

    public GameObject GetBullet()
    {
        return ObjectPooling.GetObject(bulletPrefab);
    }

    public void Eliminate(GameObject bullet)
    {
        StartCoroutine(RecicleBullet(bullet));
    }
    private IEnumerator RecicleBullet(GameObject bullet)
    {
        yield return wait;

        ObjectPooling.RecicleObject(bulletPrefab, bullet);
    }
}
