using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // キャラ選択画面に移動
    public void GameSceneLoad()
    {
        SceneManager.LoadScene("CharaSelect");
    }
}
