using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timerText;
    private int second;
    private float timer;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        second = (int)timer;
        timerText.text = second.ToString();

        Save(second);
    }
    //I—¹‚ÌŠÔ‚ğ•Û‘¶
    private void Save(int time)
    {
        PlayerPrefs.SetFloat("FinishTime", time);
    }
}
