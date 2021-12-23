using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public FighterModel model;
    EnemyController enemyController;
    Animator animator;

    private int moveNumber;
    private int fightNumber;
    private float timer;
    private float hp;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        model = new FighterModel(4);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5)
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
            timer = 0;
        }
    }

    public void OnDamage()
    {
        Debug.Log("hit");

        hp = model.hp;
        hp += 1;
        if(model.hp > 5)
        {
            hp = model.hp;
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
                return;
        }
    }
}
