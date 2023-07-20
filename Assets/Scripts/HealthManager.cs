using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

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

    private void Die()
    {
        GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
        GameObject Hero = GameObject.FindGameObjectWithTag("Clone");
        // Handle object destruction or any other necessary actions when health reaches zero.
        Destroy(gameObject);

        if (Enemy != null)
        {
            SceneManager.instance.gameoverPanael.SetActive(true);
            SceneManager.instance.winLoseTxt.text = "You Win";
            //you win
        }
        if(Hero != null)
        {
            SceneManager.instance.gameoverPanael.SetActive(true);
            SceneManager.instance.winLoseTxt.text = "You lose";
            //you lose
        }


    }
}
