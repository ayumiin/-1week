using System;
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
    public void Movement(float z)
    {
        z = Input.GetAxis("Horizontal");

        if (characterController.isGrounded)
        {
            if (playerManager.distance < 1.2)
            {
                //�������̈ړ�
                moveDirection = new Vector3(0, 0, Math.Abs(z) * playerManager.model.moveSpeed);
                animator.SetFloat("speed", Mathf.Abs(z));
            }
            else
            {
                moveDirection = new Vector3(0, 0, -z * playerManager.model.moveSpeed);
                animator.SetFloat("speed", Mathf.Abs(z));
            }
            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = playerManager.model.moveJump;
            }
        }
        moveDirection.y -= 10 * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }
    //�U���i�p���`�j
    public void Punch()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(punchPoint.position, attackRadius, enemyLayer);
        foreach (Collider hitenemy in hitEnemys)
        {
            hitenemy.GetComponent<EnemyManager>().OnDamage();
            playerManager.EnemyHp();
        }
        animator.SetBool("Attack", true);

    }
    //�U���i�L�b�N�j
    public void Kick()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(punchPoint.position, attackRadius, enemyLayer);

        foreach (Collider hitenemy in hitEnemys)
        {
            hitenemy.GetComponent<EnemyManager>().OnDamage();
            playerManager.EnemyHp();
            Debug.Log("attack");
        }

        animator.SetTrigger("Kick");
    }
    //�K�E�Z
    public void SpecialAttack()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(punchPoint.position, attackRadius, enemyLayer);
        animator.SetTrigger("SpecialAttack");
    }
}