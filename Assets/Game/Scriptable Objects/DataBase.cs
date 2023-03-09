using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class DataBase : ScriptableObject
{
    [Header("Assault Rifle Ñharacteristics")]
    [SerializeField] public float spread;
    [SerializeField] public float recoil;
    [SerializeField] public float fireRate;
}
