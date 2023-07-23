
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
        Invoke("CheckWinLose", 0.2f);
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
            SceneManager.instance.gameoverPanael.SetActive(true);
            SceneManager.instance.winLoseTxt.text = "Ÿou Lose";

            GameCounter.instance.countGamePlay();

        }
        else if (enemyHealth.GetCurrentHealth() <= 0)
        {
            Debug.Log("You Win!");
            SceneManager.instance.gameoverPanael.SetActive(true);
            SceneManager.instance.winLoseTxt.text = "Ÿou win";

            GameCounter.instance.countGamePlay();
        }
    }
}
