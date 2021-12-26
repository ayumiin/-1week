using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    PlayerController pc;
    PlayerManager pm;

    CapsuleCollider cc;
    private GameObject player;
    private GameObject resultPlayer;
    [SerializeField] Vector3 position;
    private void Awake()
    {
        player = (GameObject)Resources.Load("Resultplayer" + PlayerPrefs.GetInt("Data"));
        GameObject prefbObj = Instantiate(player, position, Quaternion.identity);
        prefbObj.transform.Rotate(new Vector3(0, 180, 0));

        resultPlayer = GameObject.FindGameObjectWithTag("player");

        cc = resultPlayer.GetComponent<CapsuleCollider>();
    }
}
