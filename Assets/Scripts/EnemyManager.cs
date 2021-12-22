using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Animator animator;

    public FighterModel model;

    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 5;
    }

    public void OnDamage()
    {
        hp -= 1;
        if(hp < 0)
        {
            hp = 5;
        }
    }
}
