using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Slider slider;

    [SerializeField] GameObject[] seinozi;

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
        slider = GetComponent<Slider>();
        slider.maxValue = 5;
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.instance.enemyManager.hitCount;
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
