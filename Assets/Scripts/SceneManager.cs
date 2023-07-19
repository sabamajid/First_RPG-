using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class SceneManager : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera = GameObject.Find("VirtualCameraGameObject").GetComponent<CinemachineVirtualCamera>();
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
}
