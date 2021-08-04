using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 100;
    public GameObject hiteffect;

    void OnTriggerEnter2D(Collider2D hitinfo) 
    {
        Enemy enemy = hitinfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(100);
        }
        Destroy(gameObject);  
        GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);  
        Destroy(effect, 0.2f);
    } 
}
