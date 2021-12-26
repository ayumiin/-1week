using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //当たり判定
    CapsuleCollider capsuleCollider;

    //data
    public FighterModel model;
    PlayerManager playerManager;

    public LayerMask enemyLayer;

    Rigidbody rb;
    Animator animator;
    CharacterController characterController;
    Vector3 moveDirection;

    private void Awake()
    {
        StopAllCoroutines();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerManager = GetComponent<PlayerManager>();
    }
    //jump,横移動
    public void Movement(float z)
    {
        z = Input.GetAxis("Horizontal");

        if (characterController.isGrounded)
        {
            if (playerManager.distance < 1.2)
            {
                //横方向の移動
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
    public void Punch()
    {
        StartCoroutine(CoroutinePunch());
    }
    public void Kick()
    {
        StartCoroutine(CoroutineKick());
    }
    //攻撃（パンチ）
    public IEnumerator CoroutinePunch()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(playerManager.punchPointTransform.position, playerManager.punchAttackRadius, enemyLayer);
        animator.SetBool("Attack", true);
        //0.2秒待機
        yield return new WaitForSeconds(0.2f);
        foreach (Collider hitenemy in hitEnemys)
        {
            hitenemy.GetComponent<EnemyManager>().OnDamage();
            playerManager.EnemyHp();
        }
    }
    //攻撃（キック）
    public IEnumerator CoroutineKick()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(playerManager.kickPointTransform.position, playerManager.kickAttackRadius, enemyLayer);
        animator.SetTrigger("Kick");
        //0.2秒待機
        yield return new WaitForSeconds(0.2f);
        foreach (Collider hitenemy in hitEnemys)
        {
            hitenemy.GetComponent<EnemyManager>().OnDamage();
            if(hitEnemys == null)
            {
                break;
            }
            playerManager.EnemyHp();
            Debug.Log("attack");
        }
    }
    //必殺技
    public void SpecialAttack()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(playerManager.punchPointTransform.position, playerManager.punchAttackRadius, enemyLayer);
        animator.SetTrigger("SpecialAttack");
    }
}