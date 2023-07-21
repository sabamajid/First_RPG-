using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public Material materialToChange;
    public GameObject Enemy;

    public EnemyHealthManager enemyHealthManager;
    public EnemyScaler enemyScaler;
    [SerializeField] private int newEnemyHealthValue;
    
    private void Start()
    {

        int currentEnemyHealth = enemyHealthManager.GetEnemyHealth();
       
        if (materialToChange != null)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            materialToChange.color = randomColor;
        }

        int playCount = PlayerPrefs.GetInt("PlayCount", 0);
        if (playCount >= 4)
        {
            if (Enemy.GetComponent<HealthManager>().maxHealth < 410)
            {
                newEnemyHealthValue = currentEnemyHealth + 30;
                enemyHealthManager.SetEnemyHealth(newEnemyHealthValue);
                enemyScaler.IncreaseScale();
            }
           
        }
        Enemy.GetComponent<HealthManager>().maxHealth = currentEnemyHealth;


    }
}
