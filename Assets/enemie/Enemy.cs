using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    public GameObject deatheffect;

    public float rotationSpeed = 180f;
    public float maxSpeed = 4f;
    Transform player;

    void Update () 
    {
        if(player == null) {
            // Find the player
            GameObject playerGameObject = GameObject.FindWithTag ("Player");

            if(playerGameObject != null) {
                player = playerGameObject.transform;
            }
            else{ return; }
        }
        // Rotating
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRotation = Quaternion.Euler( 0, 0, zAngle );
        transform.rotation = Quaternion.RotateTowards( transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

        //Moving
        Vector3 transformation = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        transform.position += transform.rotation * transformation;
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0 )
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject); 
        GameObject effect = Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.25f);
    }

}
