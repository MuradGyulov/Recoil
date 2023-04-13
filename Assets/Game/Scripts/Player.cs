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

    [SerializeField] private DataBase dataBase;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private ParticlePool particlePool;
    [SerializeField] private Animator shootingAnimator;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioSource weaponAudioSource;

    private bool tv;
    private bool mobile;
    private bool desctop;
    private bool gameStarted;
    private bool playerOnGround;

    private float nextFire;



    private void Start()
    {
        desctop = true;
        gameStarted = true;
    }

    private void FixedUpdate()
    {
        if (gameStarted)
        {
            if (desctop && Input.GetMouseButton(0))
            {
                Shooting();
                StopRotation();
            }
            else if (mobile && Input.touchCount > 0)
            {
                Shooting();
                StopRotation();
            }
            else if (tv)
            {
                Shooting();
                StopRotation();
            }
        }
    }

    public void Shooting()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + dataBase.fireRate;

            GameObject bullet = bulletPool.GetPooledBullet();
            shootPoint.localEulerAngles = shootPoint.forward * Random.Range(dataBase.spread, -dataBase.spread);
            bullet.transform.position = shootPoint.transform.position;
            bullet.transform.rotation = shootPoint.transform.rotation;
            bullet.SetActive(true);
            shootingAnimator.SetTrigger("Shoot");
            weaponAudioSource.PlayOneShot(dataBase.assaultRifleShootingSound);

            GunRecoil();
        }
    }

    private void GunRecoil()
    {
        rigidBody.AddForce(-transform.right * dataBase.recoil, ForceMode.Impulse);
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
        playerAudioSource.PlayOneShot(dataBase.floor);

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