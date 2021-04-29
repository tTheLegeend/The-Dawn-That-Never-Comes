using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //public Animator myAnim;
    public Transform target;
    public Transform homePos;
    public GameObject die;
    public Rigidbody2D rb;
    public Transform look;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    [SerializeField]
    private float attackRange;

    private int health = 100;

    public Transform firePoint;

    public Vector2 targetPosV2;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    public GameObject bulletPrefab;

    public GameObject meleePrefab;
    public float bulletForce = 10f;

    public bool isRanged;


    void Awake()
    {
        
        target = GameObject.Find("Player").transform;
       

    }

    void FixedUpdate()
    {
        targetPosV2 = target.position;
        Vector2 lookDir = targetPosV2 - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        look.eulerAngles = new Vector3(0, 0, angle);
    }
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            followPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {

            GoHome();
        }

        if (Time.time >= nextAttackTime)
        {

            if (Vector3.Distance(target.position, transform.position) <= attackRange)
            {
                if (isRanged)
                {
                    Shoot();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                else
                {
                    Melee();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }

        }
    }

    public void followPlayer()
    {
        //myAnim.SetBool("isMoving", true);
        //myAnim.SetFloat("MoveX", (target.position.x - transform.position.x));
        //myAnim.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

    public void GoHome()
    {
        //myAnim.SetFloat("MoveX", (homePos.position.x - transform.position.x));
        //myAnim.SetFloat("MoveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            //myAnim.SetBool("isMoving", false);
        }


    }

    public void setHealth(int dmg)
    {
        
        
            //myAnim.SetTrigger("isHurt");
            health = health + dmg;
            Debug.Log("ouch");
        
        if(health <= 0)
        {

            death();

        }
    }

    public void death()
    {
        Destroy(gameObject);

        //myAnim.SetBool("isDead", true);

        //GameObject death = Instantiate(die, transform.position, Quaternion.identity);
        //Destroy(death, .5f);
        Debug.Log("death");

    }




    public void Shoot()
    {
        //GameObject flash = Instantiate(muzzle, firePoint.position, firePoint.rotation);
        //Destroy(flash, .5f);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
    }

    public void Melee()
    {
        GameObject mAttack = Instantiate(meleePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = mAttack.GetComponent<Rigidbody2D>();
        Destroy(mAttack, 1f);
    }

    public void spawn(Transform spawnPos)
    {
        homePos = spawnPos;
        Instantiate(gameObject, spawnPos.position, spawnPos.rotation);
        
        Debug.Log("spawned enemy");
    }
}

