using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public Text timerText;
    private int second;
    private float countdownTimer = 90.0f;
    private float countupTimer;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        countupTimer += Time.deltaTime;
        countdownTimer -= Time.deltaTime;
        second = (int)countdownTimer;
        timerText.text = second.ToString();

        Save(countupTimer);

        if(second <= 0)
        {
            SceneManager.LoadScene("Result");
        }
    }
    //I—¹Žž‚ÌŽžŠÔ‚ð•Û‘¶
    private void Save(float time)
    {
        PlayerPrefs.SetFloat("FinishTime", time);
    }
}
