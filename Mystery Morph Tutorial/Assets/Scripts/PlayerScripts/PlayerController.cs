using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // movement
    public float movementSpeed, jumpForce;
    public bool isFacingRight, isJumping;
    Rigidbody2D rb;

    // ground checker
    public float radius;
    public Transform groundChecker;
    public LayerMask whatIsGround;

    // animation
    Animator anim;
    string walkParameter = "triggerWalk",
        idleParameter = "triggerIdle",
        jumpParameter = "triggerJump",
        landParameter = "triggerLand";


    public Text holyWaterCollectedUI;
    public GameObject winScreenUI;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    // karena gerakannya (rigidbody) pake physics, biar lebih presisi krn kan nilainya berubah terus
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        // velocity (kecepatan) utk GetAxis menerapkan real physics (ada percepatan)
        // sementara GetAxisRaw lebih presisi
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * movementSpeed, rb.velocity.y);

        if (move != 0)
        {
            anim.SetTrigger(walkParameter);
        }
        else
        {
            anim.SetTrigger(idleParameter);
        }

        if (move > 0 && !isFacingRight)
        {
            transform.eulerAngles = Vector2.zero;
            isFacingRight = true;
        }
        else if (move < 0 && isFacingRight)
        {
            transform.eulerAngles = Vector2.up * 180;
            isFacingRight = false;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (!IsGrounded() && !isJumping)
        {
            anim.SetTrigger(jumpParameter);
            isJumping = true;
        }
        else if (IsGrounded() && isJumping)
        {
            anim.SetTrigger(landParameter);
            isJumping = false;
        }
    }

    bool IsGrounded()
    {
        // membuat lingkaran
        return Physics2D.OverlapCircle(groundChecker.position, radius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        // menggambar visualisasi lingkaran, membantu dev agar terlihat
        Gizmos.DrawWireSphere(groundChecker.position, radius);
    }

    // Goal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HolyWater"))
        {
            GoalManager.singleton.CollectHolyWater();

            Destroy(collision.gameObject);

            holyWaterCollectedUI.text = "Holy water collected: "
                + GoalManager.singleton.holyWaterCollected.ToString()
                + "/" + GoalManager.singleton.holyWaterNeeded.ToString();
        }
        else if (collision.CompareTag("Goal"))
        {
            if (GoalManager.singleton.canEnter)
            {
                winScreenUI.SetActive(true);
            }
        }
    }
}