using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float enemySpeed = 2;
    public float hitDamage = 50;
    public float health = 100;

    public Vector2 offset = new Vector2(5f,5f);
    public Transform bomb;   //Bomb object that thief will throw
    public Transform armPosition;

    Rigidbody2D rb;
    Animator anim;

    public float nextAttackTime = 3;
    private float timeToAttack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeToAttack = Time.time;
    }

    void Update()
    {
        rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
        if (transform.position.y < -10)
            Destroy(gameObject);

        if(timeToAttack < Time.time)
        {

            anim.SetBool("Attack",true);
            timeToAttack = Time.time + nextAttackTime;
        }
    }

    public void Attack()
    {
        Transform clone = Instantiate(bomb, armPosition.position, Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().AddForce(offset, ForceMode2D.Impulse);
    }

    public void StopAttacking()
    {
        anim.SetBool("Attack", false);
    }
}
