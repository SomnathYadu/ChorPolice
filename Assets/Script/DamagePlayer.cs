using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private int playerHealth = 100;

    public void Damage(int _damageAmt)
    {
        playerHealth -= _damageAmt;
        if (playerHealth <= 0)
            Destroy(gameObject);
    }
}
