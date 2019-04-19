using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<DamagePlayer>().Damage(50);
            Debug.Log("Damaging player");
        }
        else
            Debug.Log("Exploding");
        Destroy(gameObject, 0.8f);
        gameObject.SetActive(true);
    }
}
