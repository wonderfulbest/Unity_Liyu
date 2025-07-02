using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightControllor : MonoBehaviour
{
    public static knightControllor instance; // 单例模式实例
    public Animator animator;
    private Rigidbody2D rb;


    public float speed = 1f;
    public float jumpForce = 1f;
    public float buoyancyForce = 5f; // 上浮力大小

    private bool isJumping = false;
    private bool inWater = false;
    void Start()
    {
        instance = this; // 初始化单例实例
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        isJumping = false;
    }


    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        if (moveHorizontal != 0)
        {
            animator.SetBool("isRun", true);
            if (moveHorizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // 向右
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1); // 向左
            }
        }
        else if (moveHorizontal == 0)
        {
            animator.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // 跳跃
            animator.SetBool("isRoll", true);
            isJumping = true;
        }
        else if (rb.velocity.y == 0)
        {
            animator.SetBool("isRoll", false);
            isJumping = false;
        }

        if (Input.GetKey(KeyCode.W) && inWater)
        {
            rb.velocity = new Vector2(rb.velocity.x, buoyancyForce); // 在水中向上浮动
            animator.SetBool("isRoll", false);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                animator.SetBool("isRoll", true); // 在水中跳跃
                rb.velocity = new Vector2(rb.velocity.x, buoyancyForce + 1); // 在水中向上浮动
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            inWater = true;
            rb.gravityScale = 0.5f; // 减小重力影响
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            inWater = false;
            rb.gravityScale = 1f; // 恢复重力

        }
    }

    //void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("MovingPlatform"))
    //    {
    //        shortPlatform platform = collision.gameObject.GetComponent<shortPlatform>();
    //        // 根据平台速度移动玩家
    //        transform.position += (Vector3)platform.GetVelocity();
    //    }
    //}
}
