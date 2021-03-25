using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject muzzle;

    public float bulletForce = 20f;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
    }

    void Shoot()
    {
        GameObject flash = Instantiate(muzzle, firePoint.position, firePoint.rotation);
        Destroy(flash, .5f);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
    }
}
