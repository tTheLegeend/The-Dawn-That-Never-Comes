using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    //public GameObject muzzle;

    public float bulletForce = 20f;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    public Rigidbody2D rb;
    public Transform gun;

    public Camera cam;
    public Vector2 mousePos;






    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        gun.eulerAngles = new Vector3(0, 0, angle);
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Shoot(firePoint.position, firePoint.rotation);
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
    }


    public void Shoot(Vector3 firePointPos, UnityEngine.Quaternion firePointRot)
    {
        //GameObject flash = Instantiate(muzzle, firePoint.position, firePoint.rotation);
        //Destroy(flash, .5f);
        GameObject bullet = Instantiate(bulletPrefab, firePointPos, firePointRot);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
    }
}
