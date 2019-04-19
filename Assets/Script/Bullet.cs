using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmt = 50;

    public float bulletLife = 0.5f;

    private void Start()
    {
        Destroy(gameObject, bulletLife);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<DamagEnemy>().DamageEnemy(damageAmt);
        }
        Destroy(gameObject);
    }
}
