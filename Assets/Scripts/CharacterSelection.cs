using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.TextCore.Text;

public class CharacterSelection : MonoBehaviour
{
    public static CharacterSelection instance;

    public Text Name,hlth, attackpower, experience, lvl;



    private const string PlayerPrefKey = "PlayCount";
    private const int MaxPlayCount = 5;

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
    public string[] Health, AttackPower, Experince, level;
    public int selectedCharacter = 0;
    public int selectedString = 0;
    private void Start()
    {
        //to get isLocked Status
        Invoke("TurnOffHeros", 0.5f);

        UnlockCharacter();


        //to check which characters are selected
        for (int i=0; i<Characters.Length; i++)
        {
                Characters[i].tag = "isNotSelected";

        }

        Name.text = Characters[selectedCharacter].name;
        hlth.text = Health[selectedString];
        attackpower.text = AttackPower[selectedString];
        experience.text = Experince[selectedString];
        lvl.text = level[selectedString];

        

    }

    public void TurnOffHeros()
    {
        for (int i = 1; i < Characters.Length; i++)
        {
            Characters[i].SetActive(false);
        }
    }

    public void NextCharacter()
    {
        Characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % Characters.Length;
        selectedString = (selectedString + 1) % Characters.Length;

        Name.text = Characters[selectedCharacter].name;
        hlth.text = Health[selectedString];
        attackpower.text = AttackPower[selectedString];
        experience.text = Experince[selectedString];
        lvl.text = level[selectedString];

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
        selectedString--;

        if (selectedCharacter < 0)
        {
            selectedCharacter += Characters.Length;
            selectedString += Characters.Length;


        }

        Name.text = Characters[selectedCharacter].name;
        hlth.text = Health[selectedString];
        attackpower.text = AttackPower[selectedString];
        experience.text = Experince[selectedString];
        lvl.text = level[selectedString];
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

    [System.Obsolete]
    public void startGame()
    {
       if (heroimage1 != null && heroimage2 != null && heroimage3 != null )
         {
            //    SceneManager.LoadScene(1);
            Application.LoadLevel(1);
        }
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
        int playCount = PlayerPrefs.GetInt(PlayerPrefKey, 0);
        Debug.Log("Playecount"  + playCount);
        if (playCount == MaxPlayCount)
        {
            UnlockCharacterCheck();

           
        }
    }
    public void UnlockCharacterCheck()
    {

        for (int i = 0; i < Characters.Length; i++)
        {
            HeroManager heroManager = Characters[i].GetComponent<HeroManager>();
            if (heroManager.isLocked)
            {
                // Hero is locked
                Debug.Log(Characters[i].name + " is locked.");
             
                Debug.Log(Characters[i].name + " is now unlocked.");
                PlayerPrefs.SetInt("Hero" + i, 1);
                heroManager.isLocked = false;
                PlayerPrefs.Save();

                PlayerPrefs.SetInt(PlayerPrefKey, 0);
                PlayerPrefs.Save();
                return;
            }
            else
            {
                // Hero is unlocked
                Debug.Log(Characters[i].name + " is unlocked.");
            }
            Debug.Log("already unlocked heros");
        }
        Debug.Log("All heroes are already unlocked.");
    }
}
