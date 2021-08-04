using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(EnemyShoot());
    }

    IEnumerator EnemyShoot()
    {
        while( 1 == 1 )
        {
            Debug.Log("Start Coroutine at time : " + Time.time);
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1);
            Debug.Log("Start Coroutine at time : " + Time.time);
        }
    }
}
