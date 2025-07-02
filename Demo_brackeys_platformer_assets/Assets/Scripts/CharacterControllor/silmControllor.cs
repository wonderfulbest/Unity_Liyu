using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silmControllor : MonoBehaviour
{
    public float detectionRange = 5f; // 检测范围
    public float attackRange = 1f;   // 攻击范围
    public float moveSpeed = 2f;     // 移动速度
    public float chaseSpeed = 3f;    // 追踪速度
    public int attackDamage = 10;    // 攻击伤害
    public float attackCooldown = 1f; // 攻击冷却时间

    private Transform player;
    private float lastAttackTime;
    private Rigidbody2D rb;
    public Animator animator;

    private bool isReturning = false; // 方向(false == right, true == left)
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isReturning = false; // false == right  true == left
    }

    void Update()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        float directionX = player.position.x - transform.position.x;
        if (distanceToPlayer > detectionRange)
        {
            // 玩家不在检测范围内，继续巡逻
            Patrol();

        }
        else if (distanceToPlayer <= detectionRange)
        {
            // 玩家在检测范围内
            if (distanceToPlayer > attackRange)
            {
                // 追踪玩家
                ChasePlayer(directionX);
            }
            else
            {
                // 在攻击范围内，停止移动并攻击
                StopMovement();
                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    void ChasePlayer(float X)
    {
        //Vector2 direction = (player.position - transform.position).magnitude > 0 ? (player.position - transform.position).normalized : Vector2.zero;// 计算方向向量
        //rb.velocity = direction * moveSpeed;

        float directionX = X;
        if (directionX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // 面向右侧
            rb.velocity = new Vector2(chaseSpeed, rb.velocity.y); // 确保向右移动时速度为正
        }
        else if (directionX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 面向左侧
            rb.velocity = new Vector2(-chaseSpeed, rb.velocity.y); // 确保向左移动时速度为负
        }

    }

    void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    void Attack()
    {
        // 这里实现攻击逻辑，例如：
        // - 播放攻击动画
        // - 检测玩家是否在攻击范围内
        // - 对玩家造成伤害
        animator.SetBool("isAttack", true);
        Debug.Log("敌人攻击玩家!");
        // 示例：检测玩家是否在攻击范围内
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackRange);


    }

    void Patrol()//敌人在发现玩家之前，来回移动
    {

        if (isReturning) // true == left
        {
            // 如果是返回状态，向左移动
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1); // 翻转敌人方向
        }
        else if (!isReturning) // false == right
        {
            // 向右移动
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1); // 翻转敌人方向
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            isReturning = !isReturning; // 改变返回状态
        }
    }
    // 检测玩家是否在视线范围内
    //bool CanSeePlayer()
    //{
    //    Vector2 direction = player.position - transform.position;
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRange);

    //    if (hit.collider != null && hit.collider.CompareTag("Player"))
    //    {
    //        return true;
    //    }
    //    return false;
    //}


    // 可视化检测范围（仅在编辑器中可见）
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Respawn();
        }
    }
}

