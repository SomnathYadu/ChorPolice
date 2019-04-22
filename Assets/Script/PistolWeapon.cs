using UnityEngine;
public class PistolWeapon : MonoBehaviour
{
    AudioSource audio;
    public Transform player;
    public Transform firePointPosition;
    public Transform bullet;
    public float bulletSpeed = 20f;
    float timeToShoot;
    void Start()
    {
        timeToShoot = Time.time;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(timeToShoot < Time.time)
            {
                Shoot();
                timeToShoot = 0.5f + Time.time;
                audio.Play();
            }
        }
    }

    public void Shoot()
    {
        audio.Play();
        Transform clone = Instantiate(bullet, firePointPosition.position, Quaternion.identity);
        if (player.transform.localScale.x < 0)
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
        else
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
    }
}
