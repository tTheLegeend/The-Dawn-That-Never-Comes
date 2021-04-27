using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    //public Animator animator;

    // Needed For Inventory
    public Transform hand; 
    public Transform body;
    //~~~~~~~~~~~~~~~~~~~~

    Vector2 movement;

    private int health = 100;

    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    public void setHealth(int dmg)
    {
        if (health > dmg)
        {
            //myAnim.SetTrigger("isHurt");
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
        Destroy(gameObject);

        //myAnim.SetBool("isDead", true);

        //GameObject death = Instantiate(die, transform.position, Quaternion.identity);
        //Destroy(death, .5f);
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
