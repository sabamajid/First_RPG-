using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class removeHero : MonoBehaviour
{
    string SelectedHeroName;
    string SelectedHeroNameToCompare;

    public GameObject[] Heros;

    private void Start()
    {
        Heros = CharacterSelection.instance.Characters;
    }
    public void RemoveHero()
    {
      

        SelectedHeroName = gameObject.transform.parent.gameObject.GetComponent<Image>().name;
        
      
        for(int i=0; i< Heros.Length; i++)
        {
            if (Heros[i].GetComponent<Image>().name == SelectedHeroName)
            {
                Heros[i].tag = "isNotSelected";
                CharacterSelection.instance.SelectedBtn.text = "Select";
            }
            Debug.Log("Name not matched");
        }


        gameObject.transform.parent.gameObject.GetComponent<Image>().sprite = null;

    }
}
