using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private Transform playerTransform;



    private DataBase dataBase;
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

        dataBase = Resources.Load("GameDataBase", typeof(ScriptableObject)) as DataBase;
        bulletPool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<BulletPool>();
        shootPoint = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>();
    }

    
    Vector3 lastPosition;

}