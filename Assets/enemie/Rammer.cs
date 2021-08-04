using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rammer : MonoBehaviour
{
    public int damage = 100;
    public GameObject hiteffect;

    void OnTriggerEnter2D(Collider2D hitinfo) 
    {
        string enemy = hitinfo.gameObject.name;


        if (name == "Player")
        {
            Destroy(hitinfo.gameObject);
        } 
        Destroy(gameObject);  
        GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);  
        Destroy(effect, 0.2f);
    } 
}
