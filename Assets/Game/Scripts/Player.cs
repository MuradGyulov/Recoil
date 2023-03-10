using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DataBase dataBase;

    private Weapon weapon;
    private ParticlesPool particlesPool;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    private bool gameStarted;
    private bool playerInAir;
    private bool desctop;
    private bool mobile;
    private bool tv;


    private void Start()
    {
        desctop = true; // Yandex game enviroment data user device
        weapon = transform.GetChild(0).gameObject.GetComponent<Weapon>();
        particlesPool = GetComponent<ParticlesPool>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void StartGame()
    {
        gameStarted = true;
    }


    private void Update()
    {
        if (true) // if game started
        {
            if (desctop && Input.GetMouseButton(0))
            {
                weapon.Shooting();
                StopRotation();
            }
            else if (mobile && Input.touchCount > 0)
            {
                weapon.Shooting();
                StopRotation();
            }
            else if (tv)
            {
                weapon.Shooting();
                StopRotation();
            }
        }
    }

    private void StopRotation()
    {
        if (playerInAir)
        {
            rigidBody.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerInAir = false;

        audioSource.volume = collision.impulse.magnitude * 0.1f;
        audioSource.PlayOneShot(dataBase.floor);

        ContactPoint contactPoint = collision.contacts[0];

        GameObject ps = particlesPool.GetPooledParticle();
        ps.SetActive(true);
        ps.transform.position = contactPoint.point;
        ParticleSystem dustPS = ps.GetComponent<ParticleSystem>();
        dustPS.Play();
    }

    private void OnCollisionExit(Collision collision)
    {
        playerInAir = true;
    }
}