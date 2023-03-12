using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Weapon weapon;
    private DataBase dataBase;
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private ParticlePool particlePool;

    private bool tv;
    private bool mobile;
    private bool desctop;
    private bool playerOnTheGround;
    private bool characterIsActivated;


    private void Start()
    {
        dataBase = Resources.Load("GameDataBase", typeof(ScriptableObject)) as DataBase;

        weapon = transform.GetChild(0).gameObject.GetComponent<Weapon>();
        particlePool = GameObject.FindGameObjectWithTag("ParticlePool").gameObject.GetComponent<ParticlePool>();

        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();


        desctop = true;
    }

    public void Activate_AND_DeactivateCharacter()
    {
        if (characterIsActivated) {
            characterIsActivated = false;
        }
        else if(!characterIsActivated) {
            characterIsActivated = true;
        }
    }


    private void Update()
    {
        if (true) // if game started
        {
            if (desctop && Input.GetMouseButton(0))
            {
                weapon.Shooting();
                StopRotation();
                GunRecoil();
            }
            else if (mobile && Input.touchCount > 0)
            {
                weapon.Shooting();
                StopRotation();
                GunRecoil();
            }
            else if (tv)
            {
                weapon.Shooting();
                StopRotation();
                GunRecoil();
            }
        }
    }

    private void StopRotation()
    {
        if (!playerOnTheGround)
        {
            rigidBody.angularVelocity = Vector3.zero;
        }
    }

    private void GunRecoil()
    {
        rigidBody.AddForce(-transform.right * dataBase.recoil, ForceMode.Impulse);

        if (playerOnTheGround)
        {
            rigidBody.AddTorque(-transform.forward * Random.Range(-dataBase.angularRecoil, dataBase.angularRecoil), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerOnTheGround = true;

        audioSource.volume = collision.impulse.magnitude * 0.1f;
        audioSource.PlayOneShot(dataBase.floor);

        ContactPoint contactPoint = collision.contacts[0];
        GameObject ps = particlePool.GetPooledParticle();
        ps.transform.position = contactPoint.point;
        ps.SetActive(true);

    }

    private void OnCollisionExit(Collision collision)
    {
        playerOnTheGround = false;
    }
}