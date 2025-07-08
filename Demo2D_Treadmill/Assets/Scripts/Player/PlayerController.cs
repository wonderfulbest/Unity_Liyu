using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody2D组件
    private Animator animator; // 动画控制器
    private bool isJumping = false; // 是否正在跳跃
    private bool isSliding = false; // 是否正在滑行
    //private bool isClimbing = false; // 是否正在攀爬
    //private bool isClimbingTrigger = false; // 是否触发攀爬
    private bool isTreadmill;
    public float moveSpeed = 5f; // 玩家移动速度
    public float jumpForce = 10f; // 跳跃力
    private BoxCollider2D boxCollider; // 玩家BoxCollider2D组件
    private Collider2D wallCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 获取Rigidbody2D组件
        animator = GetComponent<Animator>(); // 获取Animator组件
        isJumping = false; // 初始化跳跃状态为false
        boxCollider = GetComponent<BoxCollider2D>(); // 获取BoxCollider2D组件
        float y = boxCollider.size.y; // 获取BoxCollider2D的高度
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // 向左移动
            animator.SetBool("isRun", true); // 设置跑步动画状态
            transform.localScale = new Vector3(-1, 1, 1); // 面向左侧
        }
        if (Input.GetKey(KeyCode.D)) // 检测D键按下
        {

            Player_information.instance.AddScore(Time.deltaTime * 2f); // 每次移动增加1分


            animator.SetBool("isRun", true); // 设置跑步动画状态
            transform.localScale = new Vector3(1, 1, 1); // 面向右侧
        }
        else if (Input.GetKeyUp(KeyCode.D))// 如果没有水平输入
        {
            rb.velocity = new Vector2(-1, rb.velocity.y);
            animator.SetBool("isRun", false); // 设置静止动画状态
        }

        if (Input.GetKeyDown(KeyCode.W) && !isJumping) // 检测空格键按下
        {
            isJumping = true; // 设置跳跃状态为true
            rb.AddForce(new Vector2(0, jumpForce)); // 添加向上的力
            animator.SetBool("isJump", true); // 设置跳跃动画触发器
        }

        if (Input.GetKey(KeyCode.S) && !isSliding)
        {
            isSliding = true; // 设置滑行状态为true
            boxCollider.size = new Vector2(boxCollider.size.x, 0.05f); // 设置BoxCollider2D的高度为0.2
            animator.SetBool("isSlide", true); // 设置滑行动画触发器
        }

        //if (isClimbingTrigger && Input.GetKeyDown(KeyCode.E) && !isClimbing) // 检测空格键按下并且处于攀爬状态
        //{
        //    StartClimbing();
        //}

    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Treadmill"))
    //    {
    //        isTreadmill = true;

    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Treadmill"))
    //    {
    //        isTreadmill = false; // 离开跑步机时设置为false
    //    }
    //}

    //void StartClimbing()
    //{
    //    isClimbing = true;
    //    rb.gravityScale = 0; // 取消重力影响
    //    rb.velocity = Vector2.zero;
    //    // 将玩家位置对齐到墙面
    //    float wallX = wallCollider.bounds.min.x;
    //    float wallY = wallCollider.bounds.max.y;
    //    animator.SetBool("isClimb", true);
    //    gameObject.transform.position = new Vector2(wallX - 0.1f, wallY - 0.2f);
    //}
    //public void FinshClimb()
    //{
    //    isClimbing = false; // 设置攀爬状态为false
    //    // 将玩家位置对齐到墙面
    //    float wallX = wallCollider.bounds.min.x;
    //    float wallY = wallCollider.bounds.max.y;
    //    gameObject.transform.position = new Vector2(wallX + 0.1f, wallY + 0.2f);
    //    rb.gravityScale = 1; // 恢复重力影响
    //    animator.SetBool("isClimb", false); // 重置攀爬动画状态
    //}
    public void set_isJump()
    {
        isJumping = false; // 重置跳跃状态
        animator.SetBool("isJump", false); // 重置跳跃动画状态
    }
    public void set_isSliding()
    {
        isSliding = false;
        animator.SetBool("isSlide", false); // 重置滑行动画状态
        boxCollider.size = new Vector2(boxCollider.size.x, 0.34f);
    }
}
