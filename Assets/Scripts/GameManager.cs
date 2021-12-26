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


    public GameObject[] seinozi;

    //public GameObject[] Fighter;

    [SerializeField] Vector3 playerPosition;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
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

    void Update()
    {
         
        switch (playerManager.number)
        {
            case 0:
                return;
            case 1:
                seinozi[0].SetActive(true);
                break;
            case 2:
                seinozi[1].SetActive(true);
                break;
            case 3:
                seinozi[2].SetActive(true);
                break;
            case 4:
                seinozi[3].SetActive(true);
                break;
            case 5:
                seinozi[4].SetActive(true);
                break;
        }
    }
}
