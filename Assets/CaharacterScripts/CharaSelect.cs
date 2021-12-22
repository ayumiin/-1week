using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharaSelect : MonoBehaviour
{
    public Text selectText;
    public GameObject selectButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectImage(int number)
    {
        switch(number)
        {
            case 0 :
                selectText.text = "1人目";
                break;

            case 1:
                selectText.text = "2人目";
                break;

            case 2:
                selectText.text = "3人目";
                break;

            case 3:
                selectText.text = "4人目";
                break;
        }
    }

    public void OnClickText()
    {
        selectText.text = "このキャラでいいですか？";
        selectButton.SetActive(true);
    }

    public void YesNoSelect(int number)
    {
        switch (number)
        {
            case 0:
                SceneManager.LoadScene("Game");
                break;
            case 1:
                selectText.text = "キャラを選んでください";
                selectButton.SetActive(false);
                break;
        }
    }
}
