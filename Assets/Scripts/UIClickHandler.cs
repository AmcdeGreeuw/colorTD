using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIClickHandler : MonoBehaviour
{
    //Set all panels on inactive except main

    GameObject canvas;
    GameObject[] panels;
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        int childAmount = canvas.transform.childCount;
        panels = getDirectChildren(childAmount, canvas);
        Type buttonType = typeof(Button);
        getAllChildrenOfType(panels[(int)PanelType.main], buttonType);
    }

    GameObject[] getDirectChildren(int childAmount, GameObject parentObj)
    {
        GameObject[] children = new GameObject[childAmount];
     
            for (int i = 0; i < childAmount; i++)
            {
                children[i] = parentObj.transform.GetChild(i).gameObject;
            }   

        return children;
    }

    GameObject[] getChildrenByName(string[] names, GameObject parentObj)
    {
        GameObject[] children = new GameObject[names.Length];
        for (int i = 0; i < names.Length; i++)
        {
            children[i] = parentObj.transform.Find(names[i]).gameObject;
            if (names[i] != null)
            {
                Debug.Log("Warning no name found at index:" + i);
            }
        }

        return children;
    }


    GameObject[] getAllChildrenOfType(GameObject parentObj, Type type)
    {
        GameObject[] filtered = parentObj.transform.GetComponentsInChildren(type)
                  .Select(i => i.gameObject)
                  //.Take(childAmount)
                  .ToArray();

        return filtered;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void towerButton()
    {
        Onclick.addlistern(funcite);
    }







    enum PanelType
    {
        main, tower, exit
    }
}
