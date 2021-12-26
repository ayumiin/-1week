using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour
{
    EnemyManager enemyManager;
    [SerializeField] GameObject enemy;
    public Slider slider;

    private void Awake()
    {
        slider.value = 0.0f;
        slider = GetComponent<Slider>();
        enemyManager = enemy.GetComponent<EnemyManager>(); 
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemyManager.hitCount;
    }
}
