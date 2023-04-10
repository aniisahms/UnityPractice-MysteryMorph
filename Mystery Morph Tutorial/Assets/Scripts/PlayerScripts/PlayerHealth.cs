using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject[] healthUI;

    void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            health = 0;
            // load ulang scene yg sedang aktif sekarang, ibarat mati kalah
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        healthUI[health].SetActive(false);
    }

    // panggil TakeDamage ketika player bersentuhan dengan enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage();
        }
        else if (collision.CompareTag("Spikes"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
