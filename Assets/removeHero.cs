using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class removeHero : MonoBehaviour
{
    public void RemoveHero()
    {
      gameObject.transform.parent.gameObject.GetComponent<Image>().sprite = null;
    }
}
