using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    [SerializeField] private int ammountInParticlesPool;
    [SerializeField] private GameObject particlePrefab;

    private List<GameObject> pooledParticles;


    private void Start()
    {
        pooledParticles = new List<GameObject>();
        GameObject particleInstace;

        for (int i = 0; i < ammountInParticlesPool; i++)
        {
            particleInstace = Instantiate(particlePrefab);
            particleInstace.SetActive(false);
            particleInstace.transform.position = new Vector3(0, 0, 0);
            pooledParticles.Add(particleInstace);
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
        GameObject particleInstace = Instantiate(particlePrefab);
        pooledParticles.Add(particleInstace);
        return particleInstace;
    }
}