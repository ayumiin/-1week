using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //動きに関する処理
    PlayerController pc;

    //Playerのデータ
    public FighterModel model;
    Animator animator;

    //必殺技の実装
    public int number;
    public GameObject enemy;

    //enemyの取得
    EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = enemy.GetComponent<EnemyManager>();
        pc = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        //gameManager = GameManager.instance;
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
        pc.Movement();

        if(Input.GetKeyDown(KeyCode.W))
        {
            pc.Punch();
            enemyManager.FightGame();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            pc.Kick();
            enemyManager.FightGame();
        }
        if (number >= 5)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                pc.SpecialAttack();
                enemyManager.FightGame();
            }
        }
    }
    public void SpecialAttackCount()
    {
        number++;
    }
    public void EnemyHp()
    {
        if (enemyManager.model.hp >= 5)
        {
            SpecialAttackCount();
        }
    }

}
