using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum WeaponSelection
    {
        AssaultRifle,
        SniperRifle,
        ShootGun,
        MiniGun
    }
    [SerializeField] private WeaponSelection weaponSelection;

    [Space(50)]

    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private ParticlePool particlePool;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AssaultRifle assaultRifleScript;
    [SerializeField] private ShootGun shootGunScripts;

    [Space(50)]

    [SerializeField] private GameObject assaultRifle;
    [SerializeField] private GameObject sniperRifle;
    [SerializeField] private GameObject shootGun;
    [SerializeField] private GameObject miniGun;

    private bool tv;
    private bool mobile;
    private bool desctop;
    private bool gameStarted;
    private bool playerOnGround;
   

    private void Start()
    {
        desctop = true;
        gameStarted = true;

        ActivateGun();
    }

    private void ActivateGun()
    {
        switch (weaponSelection)
        {
            case WeaponSelection.AssaultRifle:
                assaultRifle.SetActive(true);
                break;
            case WeaponSelection.SniperRifle:
                sniperRifle.SetActive(true);
                break;
            case WeaponSelection.ShootGun:
                shootGun.SetActive(true);
                break;
            case WeaponSelection.MiniGun:
                miniGun.SetActive(true);
                break;
        }
    }

    private void FixedUpdate()
    {
        if (gameStarted)
        {
            if (desctop && Input.GetMouseButton(0))
            {
                StopRotation();
                Shooting();
            }
            else if (mobile && Input.touchCount > 0)
            {
                StopRotation();
                Shooting();

            }
            else if (tv)
            {
                StopRotation();
                Shooting();
            }
        }
    }

    private void Shooting()
    {
        switch (weaponSelection)
        {
            case WeaponSelection.AssaultRifle:
                assaultRifleScript.Shoot();
                break;
            case WeaponSelection.ShootGun:
                shootGunScripts.Shoot();
                break;
        }
    }

    private void StopRotation()
    {
        if (!playerOnGround)
        {
            rigidBody.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerOnGround = true;

        playerAudioSource.volume = collision.impulse.magnitude * 0.01f;
        playerAudioSource.Play();

        ContactPoint contactPoint = collision.contacts[0];
        GameObject ps = particlePool.GetPooledParticle();
        ps.transform.position = contactPoint.point;
        ps.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        playerOnGround = false;
    }

    public void Paused()
    {
        gameStarted = false;
        rigidBody.isKinematic = true;
    }

    public void Resume()
    {
        gameStarted = true;
        rigidBody.isKinematic = false;
    }
}