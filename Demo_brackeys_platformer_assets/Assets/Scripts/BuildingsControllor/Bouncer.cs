using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public Animator animator; // 用于控制弹跳器动画
    [Header("弹跳设置")]
    public float initialBounceForce = 15f;  // 初始弹跳力
    public float bounceReduction = 0.8f;    // 每次弹跳力减少的比例
    public int maxBounces = 5;              // 最大弹跳次数

    private float currentBounceForce;
    private int bounceCount = 0;
    //private bool playerOnBouncer = false;
    private GameObject TagObject;
    private void Start()
    {
        currentBounceForce = initialBounceForce;
        animator = GetComponent<Animator>();
        animator.SetBool("isBounce", false); // 确保初始状态为未弹跳
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测玩家是否踩在弹跳器上
        if (collision.gameObject.CompareTag("Player") &&
            collision.contacts[0].normal.y < -0.5f) // 从上方碰撞
        {
            TagObject = collision.gameObject;
            //playerOnBouncer = true;
            bounceCount = 0; // 重置弹跳计数
            currentBounceForce = initialBounceForce; // 重置弹跳力
            //播放弹跳器动画
            animator.SetBool("isBounce", true);
            // 第一次弹跳
            Invoke("Play_BouncePlayer", 0.3f); // 延时调用，确保动画播放
            //BouncePlayer(collision.gameObject);

        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    // 玩家在弹跳器上时持续检测
    //    if (playerOnBouncer && collision.gameObject.CompareTag("Player"))
    //    {
    //        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

    //        // 当玩家开始下落时进行下一次弹跳
    //        if (playerRb.velocity.y <= 0)
    //        {
    //            BouncePlayer(collision.gameObject);
    //        }
    //    }
    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //playerOnBouncer = false;
            // 停止弹跳器动画
            animator.SetBool("isBounce", false); // 停止弹跳器动画
        }
    }

    private void BouncePlayer(GameObject player)
    {
        if (bounceCount >= maxBounces) return;

        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        playerRb.velocity = new Vector2(playerRb.velocity.x, 0); // 重置y速度
        playerRb.AddForce(Vector2.up * currentBounceForce, ForceMode2D.Impulse);

        // 减少下一次的弹跳力
        currentBounceForce *= bounceReduction;
        bounceCount++;

        // 最后一次弹跳后标记玩家离开
        if (bounceCount >= maxBounces)
        {
            //playerOnBouncer = false;
        }
    }
    public void Play_BouncePlayer()
    {
        BouncePlayer(TagObject);
    }
}