using UnityEngine;

public class DustParticle : MonoBehaviour
{
    private void OnEnable()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        Invoke("DisbaleTheObject", particleSystem.main.duration);
    }

    private void DisbaleTheObject()
    {
        gameObject.transform.position= Vector3.zero;
        gameObject.SetActive(false);
    }
}
