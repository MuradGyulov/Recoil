using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AssaultRifle assaultRifle;

    private bool mobile;
    private bool desctop;
    private bool gameStarted;
    private bool playerOnGround;
   

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
                StopRotation();
                assaultRifle.Shoot();
            }
            else if (mobile && Input.touchCount > 0)
            {
                StopRotation();
                assaultRifle.Shoot();
            }
        }
    }

    private void StopRotation()
    {
        if (!playerOnGround)
        {
            rigidBody.angularVelocity = Vector3.zero;
        }
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
    private void OnCollisionEnter(Collision collision)
    {
        playerOnGround = true;
        playerAudioSource.volume = collision.impulse.magnitude * 0.01f;
        playerAudioSource.Play();
    }
    private void OnCollisionExit(Collision collision)
    {
        playerOnGround = false;
    }
}