using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharaSelect : MonoBehaviour
{
    public Text selectText;
    public GameObject selectButton;
    public GameObject clickButton;

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

                selectText.text = "�S�Ă̔\�͂ɂ����ĕ��ϒl�������o�����X�^�C�v";
                selectButton.SetActive(false);
                clickButton.SetActive(true);
                break;

            case 1:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "�������r�q�ő����������Ƃ��ł���X�s�[�h�^�C�v";
                selectButton.SetActive(false);
                clickButton.SetActive(true);
                break;

            case 2:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "�U���l�������p���[�^�C�v";
                selectButton.SetActive(false);
                clickButton.SetActive(true);
                break;

            case 3:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "�h��\�͂������f�B�t�F���X�^�C�v";
                selectButton.SetActive(false);
                clickButton.SetActive(true);
                break;
        }
    }

    public void OnClickText()
    {
        selectText.text = "���̃L�����ł����ł����H";
        selectButton.SetActive(true);
        clickButton.SetActive(false);
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
