using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAnimetor : StateMachineBehaviour
{
    //始めの状態はAttackをfalseにして使えないようにします。
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
    }
    //もしマウスの左クリックが押されたらAttackをtrueにしてアニメーションを使えるようにするよ！
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Attack", true);
        }
    }
    //それ以外の状態ではAttackのアニメーションはfalseにします。
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
    }
}
