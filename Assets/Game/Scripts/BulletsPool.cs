using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] int ammountInBulletsPool;
    [SerializeField] private GameObject bulletPrefab;

    public List<GameObject> pooledBullets;


    private void Start()
    {
        pooledBullets = new List<GameObject>();
        GameObject bulletInstace;

        for (int i = 0; i < ammountInBulletsPool; i++)
        {
            bulletInstace = Instantiate(bulletPrefab);
            bulletInstace.SetActive(false);
            bulletInstace.transform.position = new Vector3(0, 0, 0);
            pooledBullets.Add(bulletInstace);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < ammountInBulletsPool; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }

        return CreateMoreBullets();
    }

    private GameObject CreateMoreBullets()
    {
        GameObject bulletInstace = Instantiate(bulletPrefab);
        pooledBullets.Add(bulletInstace);
        return bulletInstace;
    }
}