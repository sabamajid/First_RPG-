using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCharacter : MonoBehaviour
{

    public GameObject[] characterPrefabs;
    public Transform[] spawnPoint;
    public Text Name;
    private int pos;

    private void Start()
    {
        int[] selectedCharacter = { PlayerPrefs.GetInt("selectedCharacter1"), PlayerPrefs.GetInt("selectedCharacter2"), PlayerPrefs.GetInt("selectedCharacter3"), };
      

        for (int i=0; i<selectedCharacter.Length; i++)
        {
           

            GameObject prefab = characterPrefabs[selectedCharacter[i]];
            GameObject clone = Instantiate(prefab, spawnPoint[pos].position, Quaternion.identity);
            pos ++;

            Name.text = prefab.name;
        }

     
    }
}
