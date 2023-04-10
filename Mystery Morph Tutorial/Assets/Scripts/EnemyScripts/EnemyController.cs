using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // movement
    public float movementSpeed;
    public bool isFacingRight;

    // arah healthbar enemy
    public Transform healthBarHUD;

    // checker
    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask whatIsGround;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

        if (!ThereIsGround())
        {
            if (isFacingRight)
            {
                // arah healthbar enemy
                healthBarHUD.localEulerAngles = Vector2.zero;

                // arah enemy
                transform.eulerAngles = Vector2.up * 180;
                isFacingRight = false;
            }
            else
            {
                // arah healthbar enemy
                healthBarHUD.localEulerAngles = Vector2.up * 180;

                //arah enemy
                transform.eulerAngles = Vector2.zero;
                isFacingRight = true;
            }
        }
    }

    bool ThereIsGround()
    {
        // jika overlap circle ini menyentuh ground, ThereIsGround() == true
        return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
    }
}
