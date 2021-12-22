using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
    public LayerMask enemyLayer;

    Rigidbody rb;
    Animator animator;
    CharacterController characterController;
    Vector3 moveDirection;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerManager = GetComponent<PlayerManager>();
    }
    //jump,���ړ�
    public void Movement()
    {
        float z = Input.GetAxis("Horizontal");

        if (characterController.isGrounded)
        {
            //�������̈ړ�
            moveDirection = new Vector3(0, 0, -z);
            animator.SetFloat("speed", Mathf.Abs(z));

            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //animator.SetTrigger("jump");
                moveDirection.y = 5;
            }
        }
        moveDirection.y -= 10 * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }
    //�U���i�p���`�j
    public void Punch()
    {
        Collider[] hitEnemys = Physics.OverlapCapsule(punchPoint.position, punchPoint.position, attackRadius, enemyLayer);
        foreach(Collider hitenemy in hitEnemys)
        {
            hitenemy.GetComponent<EnemyManager>().OnDamage();
            playerManager.EnemyHp();
        }
        animator.SetTrigger("Punch");
    }
    public void Kick()
    {
        Collider[] hitEnemys = Physics.OverlapCapsule(kickPoint.position, kickPoint.position, attackRadius, enemyLayer);

        foreach (Collider hitenemy in hitEnemys)
        {
            hitenemy.GetComponent<EnemyManager>().OnDamage();
            playerManager.EnemyHp();
        }

        animator.SetTrigger("Kick");
    }
    public void SpecialAttack()
    {
        Collider[] hitEnemys = Physics.OverlapCapsule(punchPoint.position, punchPoint.position, attackRadius, enemyLayer);
        animator.SetTrigger("SpecialAttack");
    }
}