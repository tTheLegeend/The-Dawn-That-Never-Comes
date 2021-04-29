using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    // Needed For Inventory
    public Transform hand; 
    public Transform body;
    //~~~~~~~~~~~~~~~~~~~~

    // Needed for Key 
    public Transform keyFollowPoint;
    public Key followingKey;

    Vector2 movement;
    
    public int health = 100;

    public Canvas gameOver;

    private void Start()
    {
        gameOver.gameObject.SetActive(false);
    }
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    public void setHealth(int dmg)
    {
        
            //myAnim.SetTrigger("isHurt");
            health = health + dmg;
            Debug.Log("ouch");

        if (health < 0)
        {
            death();
        }

        
    }

    public void death()
    {
        gameOver.gameObject.SetActive(true);

        //myAnim.SetBool("isDead", true);

        //GameObject death = Instantiate(die, transform.position, Quaternion.identity);
        //Destroy(death, .5f);
        Debug.Log("death");

    }

    
}
