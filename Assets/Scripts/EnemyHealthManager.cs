using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
 

    public int defaultEnemyHealth = 100;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("EnemyHealth"))
        {
            PlayerPrefs.SetInt("EnemyHealth", defaultEnemyHealth);
            PlayerPrefs.Save();
        }
    }

    public void SetEnemyHealth(int newHealth)
    {
        PlayerPrefs.SetInt("EnemyHealth", newHealth);
        PlayerPrefs.Save();
    }

    public int GetEnemyHealth()
    {
        return PlayerPrefs.GetInt("EnemyHealth", defaultEnemyHealth);
    }
}
