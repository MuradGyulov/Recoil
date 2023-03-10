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

    [Space(20)]

    [SerializeField] private DataBase dataBase;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private BulletsPool bulletsPool;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private Animator shootinAnimation;

    private float nextFire;

    public void Shooting()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + dataBase.fireRate;

            GameObject bullet = bulletsPool.GetPooledBullet();
            shootPoint.transform.localEulerAngles = new Vector3(0, 0, Random.Range(dataBase.spread, -dataBase.spread));

            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;

            shootinAnimation.SetTrigger("Shoot");
            audioSource.PlayOneShot(dataBase.assaultRifleShootingSound);
            bullet.SetActive(true);
            GunRecoil();
        }
    }

    private void GunRecoil()
    {
        playerRigidBody.AddForce(transform.right * -dataBase.recoil, ForceMode.Impulse);
    }
}