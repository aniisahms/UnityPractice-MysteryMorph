using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // objek apa yg mau dimunculkan
    public GameObject bullet;
    public Transform shotPoint;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            // spawn peluru, rotasi sesuai dgn arah player
            Instantiate(bullet, shotPoint.position, transform.rotation);
        }
    }
}
