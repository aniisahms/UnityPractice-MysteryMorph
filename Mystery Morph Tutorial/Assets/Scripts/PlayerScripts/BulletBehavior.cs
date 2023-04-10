using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed, damage, destroyTime;

    private void Awake()
    {
        // destroy peluru
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // jika peluru bersentuhan dgn objek lain
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // panggil func TakeDamage di script EnemyHealth
            collision.transform.parent.GetComponent<EnemyHealth>().TakeDamage(damage);

            // destroy peluru
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }
}