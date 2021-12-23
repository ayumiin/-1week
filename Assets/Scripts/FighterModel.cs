using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterModel 
{
    public float hp;
    public float at;
    public float df;
    public float moveJump;
    public float moveSpeed;

    public FighterModel(int fighterID)
    {
        FighterEntity fighterEntity = Resources.Load<FighterEntity>("FighterEntity" + fighterID);

        hp = fighterEntity.hp;
        at = fighterEntity.Attack;
        df = fighterEntity.Defence;
        moveJump = fighterEntity.MoveJump;
        moveSpeed = fighterEntity.MoveSpeed;
    }
}
