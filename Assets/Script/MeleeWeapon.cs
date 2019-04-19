using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] int damageAmt = 50; //Damage the weapon will do to enemy



    Player2DControl pControl;
    private void Start()
    {
        
    }


    //This method will execute when we hit something
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<DamagEnemy>().DamageEnemy(damageAmt);
        }
    }
}
