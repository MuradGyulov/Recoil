using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private Transform playerTransform;



    private Transform shootPoint;
    private BulletPool bulletPool;
    private AudioSource audioSource;
    private Animator shootinAnimation;

    private float nextFire;
    private int shootCounter;

    private void Start()
    {
        audioSource= GetComponent<AudioSource>();
        shootinAnimation= GetComponent<Animator>();

    }

    
    Vector3 lastPosition;

}