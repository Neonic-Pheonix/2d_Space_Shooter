using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int health = 100;

    public float MoveSpeed = 5f;

    public GameObject deatheffect;

    public Rigidbody2D rb; 
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; 
        rb.rotation = angle;
    }
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0 )
        {
            Die();
        }
    }

    public void Die ()
    {
        Destroy(gameObject); 
        GameObject effect = Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.25f);
    }
}
