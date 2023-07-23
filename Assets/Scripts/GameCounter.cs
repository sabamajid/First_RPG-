using Unity.VisualScripting;
using UnityEngine;

public class GameCounter : MonoBehaviour
{

    public static GameCounter instance;

    private const string PlayerPrefKey = "PlayCount";
    private const int MaxPlayCount = 4;


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
   
    }

    public void countGamePlay()
    {
        int playCount = PlayerPrefs.GetInt(PlayerPrefKey, 0);
        Debug.Log("Congratulations! You have played 5 times!" + playCount);

        if(playCount == 4)
        {

            Debug.Log("Congratulations! You have played 5 times!");
            SceneManager.instance.playAgainBtn.SetActive(false);

        }
        if (playCount > MaxPlayCount)
        {
            // Reset play count to zero
            playCount = 0;
            PlayerPrefs.SetInt(PlayerPrefKey, playCount);
            PlayerPrefs.Save();
        }
        else
        {
            // Increment the play count and save it in PlayerPrefs
            playCount++;
            PlayerPrefs.SetInt(PlayerPrefKey, playCount);
            PlayerPrefs.Save();
        }
    }

}
