using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private GameManager gameManager;
    //�����蔻��
    CapsuleCollider capsuleCollider;

    public int number;

    //data
    public FighterModel model;

    //�U��
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
    }
    //�U���i�p���`�j
    public void Punch()
    {
        animator.SetBool("Attack", true);

        if (Physics.OverlapSphere(gameManager.enemyManager.punchPointTransform.position, gameManager.enemyManager.punchAttackRadius, playerLayer).Length > 0)
        {
            gameManager.playerManager.OnDamage();
            gameManager.playerController.OnHit();
        }
        else
        {
            return;
        }
    }
    //�U���i�L�b�N�j
    public void Kick()
    {
        animator.SetTrigger("Kick");

        if (Physics.OverlapSphere(gameManager.enemyManager.kickPointTransform.position, gameManager.enemyManager.kickAttackRadius, playerLayer).Length > 0)
        {
            gameManager.playerManager.OnDamage();
            gameManager.playerController.OnHit();
        }
        else
        {
            return;
        }
    }
    //�K�E�Z
    public void SpecialAttack()
    {

        if (Physics.OverlapSphere(gameManager.enemyManager.punchPointTransform.position, gameManager.enemyManager.punchAttackRadius, playerLayer).Length > 0)
        {
            SceneManager.LoadScene("Result");
        }
        //�K�E�O��
        else
        {
            gameManager.playerManager.hitCount = 0;
            gameManager.enemyManager.number = 0;
            EnemyUIScript.instance.CountUp(number);
        }
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
