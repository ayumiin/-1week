using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�����Ɋւ��鏈��
    PlayerController pc;

    //Player�̃f�[�^
    public FighterModel model;
    GameManager gameManager;

    //�K�E�Z�̎���
    public int number;
    public GameObject enemy;
    EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = enemy.GetComponent<EnemyManager>();
        pc = GetComponent<PlayerController>();
        //gameManager = GameManager.instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        //SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        pc.Movement();

        if(Input.GetKeyDown(KeyCode.W))
        {
            pc.Punch();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            pc.Kick();
        }
        if (number >= 5)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                pc.SpecialAttack();
            }
        }
    }
    public void SpecialAttackCount()
    {
        number++;
        Debug.Log(number);
    }
    public void EnemyHp()
    {
        if (enemyManager.hp <= 0)
        {
            SpecialAttackCount();
        }
    }
    /*
    void SetUp()
    {
        switch (gameManager.GetNum())
        {
            case 0:
                model = new FighterModel(gameManager.GetNum());
                Debug.Log(model.moveJump);
                break;
            case 1:
                model = new FighterModel(gameManager.GetNum());
                break;
            case 2:
                model = new FighterModel(gameManager.GetNum());
                break;
            case 3:
                model = new FighterModel(gameManager.GetNum());
                break;
        }
    }
    */

}
