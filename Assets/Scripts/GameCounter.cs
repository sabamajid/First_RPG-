using UnityEngine;

public class GameCounter : MonoBehaviour
{
    private const string PlayerPrefKey = "PlayCount";
    private const int MaxPlayCount = 5;

    private void Start()
    {
        int playCount = PlayerPrefs.GetInt(PlayerPrefKey, 1);
        Debug.Log("Congratulations! You have played 5 times!" + playCount);
        if (playCount >= MaxPlayCount)
        {
            // Perform action for the 5th play
            Debug.Log("Congratulations! You have played 5 times!");
            // Perform your action here (e.g., show a reward, unlock a feature, etc.)

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
