using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField]
    public GameObject bulletContainer;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private List<GameObject> bulletPool;

    private void Start()
    {
        bulletPool = GenerateBullets(15);
    }

    List<GameObject> GenerateBullets(int amountOfBullets)
    {
        for (int i = 0; i < amountOfBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.parent = bulletContainer.transform;
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }        
        return bulletPool;
    }

    public GameObject RequestBullet()
    {
        foreach (var bullet in bulletPool)
        {
            if (bullet.activeInHierarchy == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.parent = bulletContainer.transform;
        bulletPool.Add(newBullet);
        return newBullet;
    }
}
