using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool playerBullet;
    public GameObject hitEffect;
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
                collision.collider.GetComponent<EnemyAI>().setHealth(-damage);
            
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            
                collision.collider.GetComponent<PlayerMovement>().setHealth(-damage);
            
        }
        if (playerBullet)
        {
            if (!collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("Player"))
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                Destroy(gameObject);

            }
        }
        else
        {
            if (!collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("Enemy"))
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                Destroy(gameObject);

            }
        }

    }

}
