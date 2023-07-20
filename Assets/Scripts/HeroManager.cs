using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour
{
    public bool isLocked;
    public int index;


    void Start()
    {
        if (PlayerPrefs.GetInt("Hero" + index, 0) == 1)
        {
            isLocked = false;

        }
        else
        {
            isLocked = true;
        }
        if (index == 0)
        {
            isLocked = false;
        }
        if (index == 1)
        {
            isLocked = false;
        }
        if (index == 2)
        {
            isLocked = false;
        }

    }

}