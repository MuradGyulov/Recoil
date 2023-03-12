using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    enum WeaponSelection
    {
        AssaultRifle,
        SniperRifle,
        ShootGun,
        MiniGun
    }
    [SerializeField] private WeaponSelection weaponSelection;

    private DataBase dataBase;
    private Transform shootPoint;
    private BulletPool bulletPool;
    private AudioSource audioSource;
    private Animator shootinAnimation;

    private float nextFire;

    private void Start()
    {
        audioSource= GetComponent<AudioSource>();
        shootinAnimation= GetComponent<Animator>();

        dataBase = Resources.Load("GameDataBase", typeof(ScriptableObject)) as DataBase;
        bulletPool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<BulletPool>();
        shootPoint = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>();
    }

    public void Shooting()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + dataBase.fireRate;

            GameObject bullet = bulletPool.GetPooledBullet();
            shootPoint.transform.localEulerAngles = new Vector3(0, 0, Random.Range(dataBase.spread, -dataBase.spread));

            bullet.transform.position = shootPoint.transform.position;
            bullet.transform.rotation = shootPoint.transform.rotation;
            bullet.SetActive(true);

            shootinAnimation.SetTrigger("Shoot");
            audioSource.PlayOneShot(dataBase.assaultRifleShootingSound);
        }
    }
}