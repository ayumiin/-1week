using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //�����蔻��
    CapsuleCollider capsuleCollider;

    //data
    public FighterModel model;
    PlayerManager playerManager;

    //�U��
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
    //�O�i
    public void moveForward()
    {
        rb.velocity = new Vector3(0, 0, 2);
    }
    //���
    public void moveBackward()
    {
        rb.velocity = new Vector3(0, 0, -2);
        Debug.Log("back");
    }
    //�U���i�p���`�j
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
    //�U���i�L�b�N�j
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
    //�K�E�Z
    public void SpecialAttack()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(punchPoint.position, attackRadius, playerLayer);
        animator.SetTrigger("SpecialAttack");
    }
    //�n�ʂɐڒn
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
        }
    }
    //�n�ʂ��痣���
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = false;
        }
    }
}
