using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform explosionEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    void Explode()
    {
        gameObject.SetActive(false);
        Transform clone = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 1f);
    }
}
