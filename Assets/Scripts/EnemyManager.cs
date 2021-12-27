using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameManager gameManager;

    public FighterModel model;
    EnemyController enemyController;
    Animator animator;

    private int moveNumber;
    private int fightNumber;
    private float timer;
    public int number;
    public float hitCount;

    //ÉvÉåÉCÉÑÅ[Ç∆ÇÃãóó£
    float distance;

    //çUåÇ
    private GameObject punchPointObject;
    public Transform punchPointTransform;
    public float punchAttackRadius;

    private GameObject kickPointObject;
    public Transform kickPointTransform;
    public float kickAttackRadius;

    private void Awake()
    {
        gameManager = GameManager.instance;

        enemyController = GetComponent<EnemyController>();
        model = new FighterModel(4);
    }

    private void Start()
    {
        hitCount = 0;
        //punchPointÇÃê›íË
        punchPointObject = GameObject.FindGameObjectWithTag("EnemypunchPoint");
        punchPointTransform = punchPointObject.transform;
        punchAttackRadius = 0.8f;
        //kickPointÇÃê›íË
        kickPointObject = GameObject.FindGameObjectWithTag("EnemykickPoint");
        kickPointTransform = punchPointObject.transform;
        kickAttackRadius = 1f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        distance = Vector3.Distance(gameManager.player.transform.position, this.transform.position);

        //StartCoroutine(EnemyAI());
        if(timer >= 0.2)
        {
            if (distance > 8)
            {
                enemyController.moveForward();
            }
            else if (distance < 1.5 && number >= 5)
            {
                enemyController.SpecialAttack();
            }
            else if (distance >= 1.7)
            {
                moveNumber = Mathf.RoundToInt(Random.Range(1, 4));
                switch (moveNumber)
                {
                    case 1:
                        enemyController.enemyJump();
                        break;
                    case 2:
                        enemyController.moveForward();
                        break;
                    case 3:
                        enemyController.moveBackward();
                        break;
                    case 4:
                        return;
                }
            }
            else if (distance < 1.7)
            {
                moveNumber = Mathf.RoundToInt(Random.Range(1, 5));
                switch (moveNumber)
                {
                    case 1:
                        enemyController.enemyJump();
                        break;
                    case 2:
                        enemyController.Punch();
                        break;
                    case 3:
                        enemyController.Kick();
                        break;
                    case 4:
                        enemyController.moveBackward();
                        break;
                    case 5:
                        return;
                }
            }
            timer = 0;
        }

    }

    public void OnDamage()
    {
        hitCount += gameManager.playerManager.model.at/gameManager.enemyManager.model.df;
        PlayerUI.instance.HitCountUp(hitCount);
        if(hitCount > model.hp)
        {
            gameManager.playerManager.SpecialAttackCount();
            hitCount = 0;
        }
    }
    public void FightGame()
    {
        fightNumber = Mathf.RoundToInt(Random.Range(1, 6));
        switch (fightNumber)
        {
            case 1:
                enemyController.Punch();
                break;
            case 2:
                enemyController.Kick();
                break;
            case 3:
                enemyController.enemyJump();
                break;
            case 4:
                enemyController.moveBackward();
                break;
            case 5:
                enemyController.moveForward();
                break;
            case 6:
                enemyController.Punch();
                return;
        }
    }
    public void SpecialAttackCount()
    {
        number++;
        EnemyUIScript.instance.CountUp(number);
    }
}
