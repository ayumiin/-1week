using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    //�����蔻��
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
    private void Update()
    {

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
                animator.SetTrigger("jump");
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
    public void OnHit()
    {
        StartCoroutine(CoroutineOnHit());
    }
    //�U���i�p���`�j
    public IEnumerator CoroutinePunch()
    {
        animator.SetTrigger("Attack");

        if (Physics.OverlapSphere(playerManager.punchPointTransform.position, playerManager.punchAttackRadius, enemyLayer).Length > 0)
        {
            GameManager.instance.enemyManager.OnDamage();

        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(0.2f);
    }
    //�U���i�L�b�N�j
    public IEnumerator CoroutineKick()
    {
        animator.SetTrigger("Kick");

        if (Physics.OverlapSphere(playerManager.kickPointTransform.position, playerManager.kickAttackRadius, enemyLayer).Length > 0)
        {
            GameManager.instance.enemyManager.OnDamage();
        }
        else
        {
            yield break; 
        }
        yield return new WaitForSeconds(0.2f);
    }
    //�K�E�Z
    public void SpecialAttack()
    {
        animator.SetTrigger("SpecialAttack");

        if (Physics.OverlapSphere(playerManager.kickPointTransform.position, playerManager.kickAttackRadius, enemyLayer).Length > 0)
        {
            GameManager.instance.isWin = true;
            GameManager.instance.IsBattle(GameManager.instance.isWin);
        }
        //�K�E�O��
        else
        {
            playerManager.number = 0;
            GameManager.instance.enemyManager.hitCount = 0;
            PlayerUI.instance.CountUp(playerManager.number);
            PlayerUI.instance.HitCountUp(GameManager.instance.enemyManager.hitCount);
        }
    }
    //�U�����󂯂�����anime
    public IEnumerator CoroutineOnHit()
    {
        animator.SetTrigger("hit");
        StopCoroutine(CoroutinePunch());
        StopCoroutine(CoroutineKick());
        yield return new WaitForSeconds(0.5f);
    }
}