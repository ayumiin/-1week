using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject obj;
    public GameObject player;
    public PlayerManager playerManager;

    public GameObject enemy;
    public EnemyManager enemyManager;

    //public GameObject[] Fighter;

    [SerializeField] Vector3 playerPosition;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        obj = (GameObject)Resources.Load("Player" + PlayerPrefs.GetInt("Data"));
        CreatePlayer();
        FindPlayer();
        FindEnemy();
    }

    private void CreatePlayer()
    {
        GameObject prefbObj = Instantiate(obj, playerPosition, Quaternion.identity);
        prefbObj.transform.position = new Vector3(-3, 4, 3);
        prefbObj.transform.Rotate(new Vector3(0, 180, 0));
    }

    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("player");
        playerManager = player.GetComponent<PlayerManager>();
    }
    public void FindEnemy()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        enemyManager = enemy.GetComponent<EnemyManager>();
    }
}
