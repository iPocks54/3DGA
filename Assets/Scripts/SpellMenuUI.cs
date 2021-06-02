using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellMenuUI : MonoBehaviour
{
    public Button[] buttons;
    FireTPPearl controller;
    GameObject[] pearls;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<FireTPPearl>();

        pearls = controller.pearls;

        Initbuttons();
        InitText();

    }

    void Update()
    {
    }

    void Initbuttons()
    {
        buttons[0].onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("Mode", 0);
            Debug.Log("Ball type set to << " + pearls[0].GetComponent<Pearl>().typeName + " >> ");
        });

        buttons[1].onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("Mode", 1);
            Debug.Log("Ball type set to << " + pearls[1].GetComponent<Pearl>().typeName + " >> ");
        });


         buttons[2].onClick.AddListener(() =>
         {
             PlayerPrefs.SetInt("Mode", 2);
             Debug.Log("Ball type set to << " + pearls[2].GetComponent<Pearl>().typeName + " >> ");
         });

         buttons[3].onClick.AddListener(() =>
         {
             PlayerPrefs.SetInt("Mode", 3);
             Debug.Log("Ball type set to << " + pearls[3].GetComponent<Pearl>().typeName + " >> ");
         }); 
    }

    void InitText()
    {
        buttons[0].GetComponentInChildren<TextMesh>().text = pearls[0].GetComponent<Pearl>().typeName;
        buttons[1].GetComponentInChildren<TextMesh>().text = pearls[1].GetComponent<Pearl>().typeName;
        buttons[2].GetComponentInChildren<TextMesh>().text = pearls[2].GetComponent<Pearl>().typeName;
        buttons[3].GetComponentInChildren<TextMesh>().text = pearls[3].GetComponent<Pearl>().typeName;

    }
}
