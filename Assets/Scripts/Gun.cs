using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    public Rigidbody2D rb;
    public GameObject player;
    public Transform gun;

    public Camera cam;
    public Vector2 mousePos;

    public int ammo = 30;
    [SerializeField]
    private int bulletsLeft;

    private bool reloading;

    public bool allowButtonDown;

    void Awake()
    {
        cam = FindObjectOfType<Camera>();
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }

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

            if (allowButtonDown)
            {
                if (Input.GetMouseButton(0) && bulletsLeft > 0)
                {
                    Shoot(firePoint.position, firePoint.rotation, firePoint);
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }

            if (Input.GetMouseButtonDown(0) && bulletsLeft > 0)
            {
                Shoot(firePoint.position, firePoint.rotation, firePoint);
                nextAttackTime = Time.time + 1f / attackRate;
            }
           

        }
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < ammo && !reloading)
        {
            Reload();
        }
          
    }
    public void Shoot(Vector3 firePointPos, UnityEngine.Quaternion firePointRot, Transform firePointT)
    {
        //GameObject flash = Instantiate(muzzle, firePoint.position, firePoint.rotation);
        //Destroy(flash, .5f);
        GameObject bullet = Instantiate(bulletPrefab, firePointPos, firePointRot);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointT.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
        bulletsLeft--;
    }
    private void Reload()
    {

        bulletsLeft = ammo;

    }
}
