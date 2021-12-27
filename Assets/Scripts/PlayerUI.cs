using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider slider;

    [SerializeField] GameObject[] seinozi;
    [SerializeField] GameObject enemy;
    [SerializeField] Text startTimer;
    EnemyManager enemyManager;
    

    public static PlayerUI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        enemyManager = enemy.GetComponent<EnemyManager>();
        slider.maxValue = 5;
    }
    // Update is called once per frame
    void Update()
    {
        if(TimeManager.startCount >= 1)
        {
            startTimer.text = TimeManager.startCount.ToString("F0");
        }
        else if(TimeManager.startCount < 1 && TimeManager.startCount >= 0)
        {
            startTimer.text = "START";
        }
        else
        {
            startTimer.text = "";
        }
        //slider.value = enemyManager.hitCount;
    }
    public void CountUp(int countNumber)
    {
        switch (countNumber)
        {
            case 0:
                for (int i = 0; i < seinozi.Length; i++)
                {
                    seinozi[i].SetActive(false);
                }
                break;
            case 1:
                seinozi[0].SetActive(true);
                break;
            case 2:
                seinozi[1].SetActive(true);
                break;
            case 3:
                seinozi[2].SetActive(true);
                break;
            case 4:
                seinozi[3].SetActive(true);
                break;
            case 5:
                seinozi[4].SetActive(true);
                break;
        }
    }
    public void HitCountUp(float hitCount)
    {
        slider.value = hitCount;
    }
}
