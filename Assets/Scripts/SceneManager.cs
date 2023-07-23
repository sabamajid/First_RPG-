using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{

    public static SceneManager instance;
    private bool isActive = false;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    //Player Side buttons
    public Button player1Btn, player2Btn, player3Btn;

    public GameObject gameoverPanael;
    public Text winLoseTxt;
    public GameObject playAgainBtn;



    private void Awake()
    {
        virtualCamera = GameObject.Find("VirtualCameraGameObject").GetComponent<CinemachineVirtualCamera>();

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
        GameObject[] cloneObjects = GameObject.FindGameObjectsWithTag("Clone");

        for (int i = 0; i < cloneObjects.Length; i++)
        {
            if(i == 0)
            {
                player1Btn.transform.GetComponentInChildren<Text>().text = cloneObjects[i].name;
            }
            if (i == 1)
            {
                player2Btn.transform.GetComponentInChildren<Text>().text = cloneObjects[i].name;
            }
            if (i == 2)
            {
                player3Btn.transform.GetComponentInChildren<Text>().text = cloneObjects[i].name;
            }

        }

     }


    public void SelectPlayer1()
    {
        GameObject[] cloneObjects = GameObject.FindGameObjectsWithTag("Clone");

        for (int i = 0; i < cloneObjects.Length; i++)
        {
            if (i == 0)
            {
                cloneObjects[i].GetComponent<CloneController>().isActive = true;
                cloneObjects[i].GetComponent<CharacterManager>().enabled = true;

                virtualCamera.LookAt = cloneObjects[i].transform;
                virtualCamera.Follow = cloneObjects[i].transform;
            }
            else
            {
                CharacterManager component = cloneObjects[i].GetComponent<CharacterManager>();
                cloneObjects[i].GetComponent<CloneController>().isActive = false;
                if (component != null)
                {

                    component.enabled = isActive;
                }
            }
        }
    }

    private void Update()
    {
        var component = GetComponent<CharacterManager>();
        if (component != null)
        {
            component.enabled = isActive;
        }
    }
    public void SelectPlayer2()
    {

        GameObject[] cloneObjects = GameObject.FindGameObjectsWithTag("Clone");

        for (int i = 0; i < cloneObjects.Length; i++)
        {
            if (i == 1)
            {
                cloneObjects[i].GetComponent<CloneController>().isActive = true;
                cloneObjects[i].GetComponent<CharacterManager>().enabled = true;

                virtualCamera.LookAt = cloneObjects[i].transform;
                virtualCamera.Follow = cloneObjects[i].transform;
            }
            else
            {
                CharacterManager component = cloneObjects[i].GetComponent<CharacterManager>();
                cloneObjects[i].GetComponent<CloneController>().isActive = false;
                if (component != null)
                {

                    component.enabled = isActive;
                }
            }
        }
    }
    public void SelectPlayer3()
    {

        GameObject[] cloneObjects = GameObject.FindGameObjectsWithTag("Clone");

        for (int i = 0; i < cloneObjects.Length; i++)
        {
            if (i == 2)
            {
                cloneObjects[i].GetComponent<CloneController>().isActive = true;
                cloneObjects[i].GetComponent<CharacterManager>().enabled = true;

                virtualCamera.LookAt = cloneObjects[i].transform;
                virtualCamera.Follow = cloneObjects[i].transform;
            }
            else
            {
                CharacterManager component = cloneObjects[i].GetComponent<CharacterManager>();
                cloneObjects[i].GetComponent<CloneController>().isActive = false;
                if (component != null)
                {

                    component.enabled = isActive;
                }
            }
        }
    }


    public void HomeBtn()
    {
        Application.LoadLevel(0);
    }

    public void PlayAgain()
    {
        Application.LoadLevel(1);
    }


}
