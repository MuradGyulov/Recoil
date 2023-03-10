using System.Collections.Generic;
using UnityEngine;

public class ParticlesPool : MonoBehaviour
{
    [SerializeField] int ammountInParticlesPool;
    [SerializeField] private GameObject particlePrefab;

    public List<GameObject> pooledParticles;


    private void Start()
    {
        pooledParticles = new List<GameObject>();
        GameObject bulletInstace;

        for (int i = 0; i < ammountInParticlesPool; i++)
        {
            bulletInstace = Instantiate(particlePrefab);
            bulletInstace.SetActive(false);
            bulletInstace.transform.position = new Vector3(0, 0, 0);
            pooledParticles.Add(bulletInstace);
        }
    }

    public GameObject GetPooledParticle()
    {
        for (int i = 0; i < ammountInParticlesPool; i++)
        {
            if (!pooledParticles[i].activeInHierarchy)
            {
                return pooledParticles[i];
            }
        }

        return CreateMoreParticles();
    }

    private GameObject CreateMoreParticles()
    {
        GameObject bulletInstace = Instantiate(particlePrefab);
        pooledParticles.Add(bulletInstace);
        return bulletInstace;
    }
}