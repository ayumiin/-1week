using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FighterEntity", menuName = "CreateFighterEntity")]
public class FighterEntity :ScriptableObject
{
    public float hp;
    public float Attack;
    public float Defence;
    public float MoveJump;
    public float MoveSpeed;
}
