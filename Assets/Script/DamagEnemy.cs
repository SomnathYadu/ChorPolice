using UnityEngine;

public class DamagEnemy : MonoBehaviour
{

    private int enemyHealth = 100;

    public void DamageEnemy(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
            GameMaster.KillEnemy(gameObject);
    }
}
