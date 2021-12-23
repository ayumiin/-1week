using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //当たり判定
    CapsuleCollider capsuleCollider;

    //data
    public FighterModel model;
    PlayerManager playerManager;

    //攻撃
    public Transform punchPoint;
    public Transform kickPoint;

    public float attackRadius;
    public LayerMask playerLayer;

    Rigidbody rb;
    Animator animator;
    Vector3 moveDirection;
    bool isGround = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerManager = GetComponent<PlayerManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

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
        Debug.Log("back");
    }
    //攻撃（パンチ）
    public void Punch()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(punchPoint.position, attackRadius, playerLayer);
        foreach (Collider hitenemy in hitEnemys)
        {
            hitenemy.GetComponent<EnemyManager>().OnDamage();
            playerManager.EnemyHp();
        }
        animator.SetTrigger("Punch");
    }
    //攻撃（キック）
    public void Kick()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(punchPoint.position, attackRadius, playerLayer);

        foreach (Collider hitenemy in hitEnemys)
        {
            hitenemy.GetComponent<EnemyManager>().OnDamage();
            playerManager.EnemyHp();
        }

        animator.SetTrigger("Kick");
    }
    //必殺技
    public void SpecialAttack()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(punchPoint.position, attackRadius, playerLayer);
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
