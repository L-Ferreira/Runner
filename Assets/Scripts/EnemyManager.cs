using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; } = null;
    private int enemiesCounter = 0;

    [SerializeField]
    private Text enemiesCounterText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseEnemiesCounter()
    {
        enemiesCounter++;
    }

    public void DecreaseEnemiesCounter()
    {
        enemiesCounter--;
    }
}
