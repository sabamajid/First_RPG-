using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public static CharacterSelection instance;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
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


        //to check which characters are selected
        for (int i=0; i<Characters.Length; i++)
        {
                Characters[i].tag = "isNotSelected";
         
        }
    }
    public void NextCharacter()
    {


        

        Characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % Characters.Length;
        Characters[selectedCharacter].SetActive(true);

        StartCoroutine(ExampleCoroutine());


        HeroSelectionCheck();

    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0f);

        if (Characters[selectedCharacter].GetComponent<HeroManager>().isLocked == true)
        {
            SelectedBtn.text = "Locked";
            SelectedBtn.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            SelectedBtn.text = "Select";
            SelectedBtn.transform.parent.gameObject.GetComponent<Button>().interactable = true;
        }
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

        if (Characters[selectedCharacter].GetComponent<HeroManager>().isLocked == true)
        {
            SelectedBtn.text = "Locked";
            SelectedBtn.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            SelectedBtn.text = "Select";
            SelectedBtn.transform.parent.gameObject.GetComponent<Button>().interactable = true;
        }

        HeroSelectionCheck();

      
    }

    public void startGame()
    {
       // PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
       // SceneManager.LoadScene(1, LoadSceneMode.Single);
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
                PlayerPrefs.SetInt("selectedCharacter1", selectedCharacter);
                heroimage1.GetComponent<Image>().sprite = Characters[selectedCharacter].GetComponent<Image>().sprite;
                Characters[selectedCharacter].tag = "isSelected";
                Character_isSelected();
                return;


            }
            if (heroimage2.sprite == null)
            {
                PlayerPrefs.SetInt("selectedCharacter2", selectedCharacter);
                heroimage2.GetComponent<Image>().sprite = Characters[selectedCharacter].GetComponent<Image>().sprite;
                Characters[selectedCharacter].tag = "isSelected";
                Character_isSelected();
                return;
            }
            if (heroimage3.sprite == null)
            {
                PlayerPrefs.SetInt("selectedCharacter3", selectedCharacter);
                heroimage3.GetComponent<Image>().sprite = Characters[selectedCharacter].GetComponent<Image>().sprite;
                Characters[selectedCharacter].tag = "isSelected";
                Character_isSelected();
                return;
            }

        }
    }

    public void Character_isSelected()
    {
        if (Characters[selectedCharacter].GetComponent<HeroManager>().isLocked)
        {
            SelectedBtn.text = "Locked";
            SelectedBtn.transform.parent.gameObject.GetComponent<Button>().interactable = false;

        }
        else
        {
            SelectedBtn.text = "Select";
            SelectedBtn.transform.parent.gameObject.GetComponent<Button>().interactable = true;
        }

        SelectedBtn.GetComponent<Text>().text = "Selected";
    }

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
    public void UnlockCharacter()
    {
        PlayerPrefs.SetInt("Hero" + selectedCharacter, 1); 
        Characters[selectedCharacter].GetComponent<HeroManager>().isLocked = false;

        SelectedBtn.text = "Select";
        SelectedBtn.transform.parent.gameObject.GetComponent<Button>().interactable = true;
    }


}
