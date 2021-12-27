using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameManager gameManager;
    //動きに関する処理
    PlayerController pc;

    //Playerのデータ
    public FighterModel model;
    Animator animator;

    //必殺技の実装
    public int number = 0;
    public bool isSpecialAttack;

    //敵との距離
    public float distance;

    //攻撃
    private GameObject punchPointObject;
    public Transform punchPointTransform;
    public float punchAttackRadius;

    private GameObject kickPointObject;
    public Transform kickPointTransform;
    public float kickAttackRadius;

    public float hitCount = 0.0f;

    private void Awake()
    {
        gameManager = GameManager.instance;
        gameManager.FindEnemy();

        pc = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();

        //punchPointの設定
        punchPointObject = GameObject.FindGameObjectWithTag("punchPoint");
        punchPointTransform = punchPointObject.transform;
        punchAttackRadius = 0.8f;
        //kickPointの設定
        kickPointObject = GameObject.FindGameObjectWithTag("kickPoint");
        kickPointTransform = punchPointObject.transform;
        kickAttackRadius = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }
    //キャラクターのステータス取得
    void SetUp()
    {
        switch (PlayerPrefs.GetInt("Data"))
        {
            case 0:
                model = new FighterModel(0);
                break;
            case 1:
                model = new FighterModel(1);
                break;
            case 2:
                model = new FighterModel(2);
                break;
            case 3:
                model = new FighterModel(3);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, gameManager.enemy.transform.position);

        pc.Movement(1);

        if (Input.GetKeyDown(KeyCode.W))
        {
            pc.Punch();
            gameManager.enemyManager.FightGame();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            pc.Kick();
            gameManager.enemyManager.FightGame();
        }
        if (number >= 5)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                pc.SpecialAttack();
                gameManager.enemyManager.FightGame();
            }
        }     
    }
    public void SpecialAttackCount()
    {
        number++;
        PlayerUI.instance.CountUp(number);
    }
    public void OnDamage()
    {
        hitCount += 1;
        EnemyUIScript.instance.HitCountUp(hitCount);
        if (hitCount > 5)
        {
           gameManager.enemyManager.SpecialAttackCount();

            hitCount = 0;
        }
    }
}
