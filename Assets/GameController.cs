
    using UnityEngine;

    public class GameController : MonoBehaviour
    {
         public static GameController instance;

        public GameObject enemy;
        public GameObject[] heroClones;

        public HealthManager enemyHealth;
        public HealthManager[] heroHealths;


        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }
        private void Start()
        {
            // Find the enemy and hero clones in the scene
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            enemyHealth = enemy.GetComponent<HealthManager>();
            Invoke("FindHeroClones", 0.1f);
            Invoke("letsTest", 0.5f);
        }

        private void letsTest()
        {
        enemy.GetComponent<HealthManager>().currentHealth =  0;


        }


    private void FindHeroClones()
    {
        // Find all hero clones in the scene
        heroClones = GameObject.FindGameObjectsWithTag("Clone");

        heroHealths = new HealthManager[heroClones.Length];
        for (int i = 0; i < heroClones.Length; i++)
        {
            heroHealths[i] = heroClones[i].GetComponent<HealthManager>();
        }
    }



    private void Update()
    {
         //   enemyHealth = enemy.GetComponent<HealthManager>();
        Invoke("CheckWinLose", 0.2f);
        // Check for win or lose conditions
        //CheckWinLose();
    }

    private void CheckWinLose()
    {
        bool allHeroesDefeated = true;
        for (int i = 0; i < heroHealths.Length; i++)
        {
            if (heroHealths[i].GetCurrentHealth() > 0)
            {
                allHeroesDefeated = false;
                break;
            }
        }

        if (allHeroesDefeated)
        {
            // All heroes are defeated, so it's a loss
            Debug.Log("You Lose!");
            // Implement actions for losing the game, e.g., show a game over screen.
            // You can call a method here to handle game over logic.
        }
        else if (enemyHealth.GetCurrentHealth() <= 0)
        {
            // Enemy is defeated, so it's a win
            Debug.Log("You Win!");
            // Implement actions for winning the game, e.g., show a victory screen.
            // You can call a method here to handle victory logic.
        }
    }
}
