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
        //�����l�̐ݒ�
        PlayerPrefs.SetInt("Data", 0);
    }

    public void SelectImage(int number)
    {
        switch(number)
        {
            case 0 :
                PlayerPrefs.SetInt("Data",number);
                selectText.text = "1�l��";
                break;

            case 1:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "2�l��";
                break;

            case 2:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "3�l��";
                break;

            case 3:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "4�l��";
                break;
        }
    }

    public void OnClickText()
    {
        selectText.text = "���̃L�����ł����ł����H";
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
                selectText.text = "�L������I��ł�������";
                selectButton.SetActive(false);
                break;
        }
    }
}
