using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{

    //Selected images of hero
    public Image heroimage1;
    public Image heroimage2;
    public Image heroimage3;

    //Button that shows Character is Selected or not

    public Text SelectedBtn;
    

    public GameObject[] Characters;
    public int selectedCharacter = 0;

    private void Start()
    {
       for(int i=0; i<Characters.Length; i++)
        {
            Characters[i].tag = "isNotSelected";
        }
    }
    public void NextCharacter()
    {
        Characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % Characters.Length;
        Characters[selectedCharacter].SetActive(true);

        HeroSelectionCheck();
    }

    public void previousCharacter()
    {
     
        Characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += Characters.Length;

        }
        Characters[selectedCharacter].SetActive(true);

        HeroSelectionCheck();

    }

    public void startGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void selectHero()
    {
     
        //PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        Debug.Log(selectedCharacter);

        if (Characters[selectedCharacter].tag == "isSelected")
        {
            //Hero is already selected

        }
        if (Characters[selectedCharacter].tag == "isNotSelected")
        {
            if (heroimage1.sprite == null)
            {
                heroimage1.GetComponent<Image>().sprite = Characters[selectedCharacter].GetComponent<Image>().sprite;
                Characters[selectedCharacter].tag = "isSelected";
                Character_isSelected();
                return;


            }
            if (heroimage2.sprite == null)
            {
                heroimage2.GetComponent<Image>().sprite = Characters[selectedCharacter].GetComponent<Image>().sprite;
                Characters[selectedCharacter].tag = "isSelected";
                Character_isSelected();
                return;
            }
            if (heroimage3.sprite == null)
            {
                heroimage3.GetComponent<Image>().sprite = Characters[selectedCharacter].GetComponent<Image>().sprite;
                Characters[selectedCharacter].tag = "isSelected";
                Character_isSelected();
                return;
            }

        }
    }

    public void Character_isSelected()
    {
        SelectedBtn.GetComponent<Text>().text = "Selected";
    }

    //public void Character_isNotSelected()
    //{
    //    SelectedBtn.GetComponent<Text>().text = "Select";
    //}

    public void HeroSelectionCheck()
    {
        if (Characters[selectedCharacter].tag == "isSelected")
        {
            SelectedBtn.text = "Selected";

        }
        if (Characters[selectedCharacter].tag == "isNotSelected")
        {
            SelectedBtn.text = "Select";
        }
    }

}
