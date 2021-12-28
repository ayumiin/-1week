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
    public AudioSource audioSource;
    public AudioClip selectSE;
    public AudioClip cancelSE;

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

                selectText.text = "全ての能力において平均値が高いバランスタイプ";
                selectButton.SetActive(false);
                clickButton.SetActive(true); 
                audioSource.PlayOneShot(selectSE);
                break;

            case 1:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "動きが俊敏で早く動くことができるスピードタイプ";
                selectButton.SetActive(false);
                clickButton.SetActive(true);
                audioSource.PlayOneShot(selectSE);
                break;

            case 2:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "攻撃値が高いパワータイプ";
                selectButton.SetActive(false);
                clickButton.SetActive(true);
                audioSource.PlayOneShot(selectSE);
                break;

            case 3:
                PlayerPrefs.SetInt("Data", number);

                selectText.text = "防御能力が高いディフェンスタイプ";
                selectButton.SetActive(false);
                clickButton.SetActive(true);
                audioSource.PlayOneShot(selectSE);
                break;
        }
    }

    public void OnClickText()
    {
        selectText.text = "このキャラでいいですか？";
        selectButton.SetActive(true);
        clickButton.SetActive(false);
        audioSource.PlayOneShot(selectSE);
    }

    public void YesNoSelect(int number)
    {
        switch (number)
        {
            case 0:
                SceneManager.LoadScene("Game");
                audioSource.PlayOneShot(selectSE);
                break;
            case 1:
                selectText.text = "キャラを選んでください";
                selectButton.SetActive(false);
                audioSource.PlayOneShot(cancelSE);
                break;
        }
    }
}
