using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject[] tutorialImage;
    public AudioSource audioSource;
    public AudioClip selectSE;
    public AudioClip clickSE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick(int number)
    {
        switch (number)
        {
            case 0:
                tutorialPanel.SetActive(true);
                tutorialImage[0].SetActive(true);
                audioSource.PlayOneShot(clickSE);
                break;

            case 1:
                tutorialImage[1].SetActive(true);
                tutorialImage[0].SetActive(false);
                audioSource.PlayOneShot(clickSE);
                break;

            case 2:
                tutorialImage[2].SetActive(true);
                tutorialImage[1].SetActive(false);
                audioSource.PlayOneShot(clickSE);
                break;

            case 3:
                tutorialImage[3].SetActive(true);
                tutorialImage[2].SetActive(false);
                audioSource.PlayOneShot(clickSE);
                break;

            case 4:
                tutorialImage[1].SetActive(false);
                tutorialImage[0].SetActive(true);
                audioSource.PlayOneShot(clickSE);
                break;

            case 5:
                tutorialImage[2].SetActive(false);
                tutorialImage[1].SetActive(true);
                audioSource.PlayOneShot(clickSE);
                break;

            case 6:
                tutorialImage[3].SetActive(false);
                tutorialImage[2].SetActive(true);
                audioSource.PlayOneShot(clickSE);
                break;

            case 7:
                audioSource.PlayOneShot(selectSE);
                SceneManager.LoadScene("CharaSelect");
                break;
        }
    }
}
