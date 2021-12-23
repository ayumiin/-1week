using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharaSelect : MonoBehaviour
{
    public Text selectText;
    public GameObject selectButton;

    public int N;

    public void SelectImage(int number)
    {
        N = number;
        switch(N)
        {
            case 0 :
                PlayerPrefs.SetInt("Data",N);
                selectText.text = "1人目";
                Debug.Log(N);
                break;

            case 1:
                PlayerPrefs.SetInt("Data", N);

                selectText.text = "2人目";
                break;

            case 2:
                PlayerPrefs.SetInt("Data", N);

                selectText.text = "3人目";
                break;

            case 3:
                PlayerPrefs.SetInt("Data", N);

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
