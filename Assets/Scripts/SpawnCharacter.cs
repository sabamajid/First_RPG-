using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCharacter : MonoBehaviour
{

    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public Text Name;

    private void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        Name.text = prefab.name;
    }
}
