using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharaSelect : MonoBehaviour
{
    public Text selectText;
    public GameObject selectButton;

    private void Awake()
    {
        //初期値の設定
        PlayerPrefs.SetInt("Data", 0);
    }

    public void SelectImage(int number)
    {
        switch(number)
        {
            case 0 :
                PlayerPrefs.SetInt("Data",number);
                selectText.text = "1人目";
                break;

            case 1:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "2人目";
                break;

            case 2:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "3人目";
                break;

            case 3:
                PlayerPrefs.SetInt("Data", number);

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
