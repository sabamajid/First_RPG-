using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        Debug.Log("healtthhhh"+currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public float GetCurrentHealth()
    {
        // Return the current health
        return currentHealth;
    }
    private void Die()
    {

        //GameController.instance.CheckWin();
        //GameController.instance.CheckWin();

        //CheckLose();
        //GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
        //GameObject[] Hero = GameObject.FindGameObjectsWithTag("Clone");
        // Handle object destruction or any other necessary actions when health reaches zero.
        Destroy(gameObject);

        //if (Enemy == null)
        //{
        //    Debug.Log("enemy is dead");
        //    //SceneManager.instance.gameoverPanael.SetActive(true);
        //    //SceneManager.instance.winLoseTxt.text = "You Win";
        //    //you win
        //}
        //if (Hero.Length <= 0)
        //{
        //    Debug.Log("hero is dead");
        //    //SceneManager.instance.gameoverPanael.SetActive(true);
        //    //SceneManager.instance.winLoseTxt.text = "You lose";
        //    //you lose
        //}
       


    }
}
