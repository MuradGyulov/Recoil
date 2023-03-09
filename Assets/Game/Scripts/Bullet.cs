using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [Space(20)]
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ParticleSystem collisionParticles;

    private void OnEnable()
    {
        boxCollider.enabled = true;
        meshRenderer.enabled = true;
        rigidBody.AddForce(transform.right * bulletSpeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            rigidBody.velocity = Vector3.zero;
            boxCollider.enabled = false;
            meshRenderer.enabled = false;
            collisionParticles.Play();
            Invoke("DeactivateTheBullet", 0.26f);
        }
    }

    private void DeactivateTheBullet()
    {
        transform.position = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
    }
}