using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public Text timerText;
    private int second;
    private float countdownTimer = 94f;
    private float countupTimer;
    public static float startCount = 3.5f;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        startCount -= Time.deltaTime;
        if(startCount >= 0)
        {
            timerText.text = "";
        }
        else
        {

            timerText.text = second.ToString();
        }
        countupTimer += Time.deltaTime;
        countdownTimer -= Time.deltaTime;
        second = (int)countdownTimer;

        Save(countupTimer);

        if(second <= 0)
        {
            SceneManager.LoadScene("Result");
            PlayerPrefs.SetInt("Result", 3);
        }
    }
    //I—¹Žž‚ÌŽžŠÔ‚ð•Û‘¶
    private void Save(float time)
    {
        PlayerPrefs.SetFloat("FinishTime", time);
    }
}
