using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    public GameObject die;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;

    private int health = 100;
    private float timePassed;
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            followPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }
    }

    public void followPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("MoveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        myAnim.SetFloat("MoveX", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, homePos.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }

        
    }

    public void setHealth(int dmg)
    {
        if (health > dmg)
        {
            myAnim.SetTrigger("isHurt");
            health = health - dmg;
            Debug.Log("ouch");
        }
        else
        {
            
                death();
            
        }
    }

    public void death()
    {
        myAnim.SetBool("isDead", true);
        Destroy(gameObject);
        GameObject death = Instantiate(die, transform.position, Quaternion.identity);
        Destroy(death, .5f);
        Debug.Log("death");
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            setHealth(20);
        }

    }


}

