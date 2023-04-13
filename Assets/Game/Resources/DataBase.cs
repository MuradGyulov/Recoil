using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class DataBase : ScriptableObject
{
    [SerializeField] public AudioClip floor;

    [Space(25)]

    [Header("Assault Rifle Ñharacteristics")]
    [SerializeField] public float spread;
    [SerializeField] public float recoil;
    [SerializeField] public float angularRecoil;
    [SerializeField] public float fireRate;
    [SerializeField] public AudioClip assaultRifleShootingSound;
}
