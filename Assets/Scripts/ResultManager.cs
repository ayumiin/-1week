using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResultManager : MonoBehaviour
{
    PlayerController pc;
    PlayerManager pm;

    CapsuleCollider cc;
    private GameObject player;
    private GameObject resultPlayer;
    [SerializeField] Vector3 position;
    [SerializeField] Text timer,resultText;
    private Animator animator;
    private GameObject prefabObj;

    private void Awake()
    {
        player = (GameObject)Resources.Load("Resultplayer" + PlayerPrefs.GetInt("Data"));
        prefabObj = Instantiate(player, position, Quaternion.identity);
    }
    private void Start()
    {
        resultPlayer = GameObject.FindGameObjectWithTag("player");
        animator = resultPlayer.GetComponent<Animator>();

        cc = resultPlayer.GetComponent<CapsuleCollider>();

        timer.text = PlayerPrefs.GetFloat("FinishTime").ToString("F2");
        if(PlayerPrefs.GetInt("Result") == 1)
        {
            resultText.text = "èüóò";
            animator.SetTrigger("WIN");
            prefabObj.transform.Rotate(new Vector3(0, 170, 0));
        }
        else
        {
            resultText.text = "îsñk";
            animator.SetTrigger("LOSE");
            prefabObj.transform.Rotate(new Vector3(0, 90, 0));
        }

    }
    public void Retry()
    {
        SceneManager.LoadScene("CharaSelect");
    }
}
