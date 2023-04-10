using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 offset;
    public float cameraSpeed;

    // Update is called once per frame
    void Update()
    {
        // Linearly interpolates between two points (Lerp)
        // memposisikan (memindahkan) vector-a terhadap vector-b secara linear
        // dengan kecepatan perpindahan
        // transform.position == posisi yg punya script ini, alias main camera

        transform.position = Vector3.Lerp(transform.position,
            playerPosition.position + offset,
            cameraSpeed * Time.deltaTime);
    }
}
