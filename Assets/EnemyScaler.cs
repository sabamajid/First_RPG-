using UnityEngine;

public class EnemyScaler : MonoBehaviour
{
    public float initialScale = 2.0f;
    public float scaleIncrement = 1.0f;
    public string enemyScaleKey = "EnemyScale";

    private void Start()
    {
        if (PlayerPrefs.HasKey(enemyScaleKey))
        {
            float savedScale = PlayerPrefs.GetFloat(enemyScaleKey);
            transform.localScale = new Vector3(savedScale, savedScale, savedScale);
        }
        else
        {
            transform.localScale = new Vector3(initialScale, initialScale, initialScale);
        }
    }
    public void IncreaseScale()
    {
        float currentScale = transform.localScale.x;
        float newScale = currentScale + scaleIncrement;
        transform.localScale = new Vector3(newScale, newScale, newScale);

        PlayerPrefs.SetFloat(enemyScaleKey, newScale);
        PlayerPrefs.Save();
    }
}
