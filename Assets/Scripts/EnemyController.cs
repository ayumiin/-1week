using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private GameManager gameManager;
    //当たり判定
    CapsuleCollider capsuleCollider;

    public bool isOnHit = false;
    public float hitCount;
    public int number;

    //data
    public FighterModel model;

    //攻撃
    public LayerMask playerLayer;

    Rigidbody rb;
    Animator animator;
    Vector3 moveDirection;
    bool isGround = false;
    private void Awake()
    {
        gameManager = GameManager.instance;
        
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        gameManager.FindPlayer();
    }
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //jump
    public void enemyJump()
    {
        if(isGround)
        {
            rb.velocity = new Vector3(0, 5, 0);
            isGround = false;
        }
    }
    //前進
    public void moveForward()
    {
        rb.velocity = new Vector3(0, 0, 2);
    }
    //後退
    public void moveBackward()
    {
        rb.velocity = new Vector3(0, 0, -2);
    }
    //攻撃（パンチ）
    public void Punch()
    {
        if (Physics.OverlapSphere(gameManager.enemyManager.punchPointTransform.position, gameManager.enemyManager.punchAttackRadius, playerLayer).Length > 0)
        {
            isOnHit = true;
            hitCount++;
        }
        else
        {
            isOnHit = false;
        }
        animator.SetBool("Attack",true);
    }
    //攻撃（キック）
    public void Kick()
    {
        if (Physics.OverlapSphere(gameManager.enemyManager.kickPointTransform.position, gameManager.enemyManager.kickAttackRadius, playerLayer).Length > 0)
        {
            isOnHit = true;
            hitCount++;
        }
        else
        {
            isOnHit = false;
        }
        animator.SetTrigger("Kick");
    }
    //必殺技
    public void SpecialAttack()
    {

        if (Physics.OverlapSphere(gameManager.enemyManager.punchPointTransform.position, gameManager.enemyManager.punchAttackRadius, playerLayer).Length > 0)
        {
            SceneManager.LoadScene("Result");
        }
        //必殺外す
        else
        {
            hitCount = 0;
            number = 0;
            EnemyUIScript.instance.CountUp(number);
        }
        animator.SetTrigger("SpecialAttack");
    }
    //地面に接地
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
        }
    }
    //地面から離れる
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = false;
        }
    }
}
