using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Weapon weapon;
    private Rigidbody rigidBody;

    private bool gameStarted;
    private bool playerInAir;
    private bool desctop;
    private bool mobile;
    private bool tv;


    private void Start()
    {
        desctop = true; // Yandex game enviroment data user device
        weapon = transform.GetChild(0).gameObject.GetComponent<Weapon>();
        rigidBody = GetComponent<Rigidbody>();
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
    }

    private void OnCollisionExit(Collision collision)
    {
        playerInAir = true;
    }
}