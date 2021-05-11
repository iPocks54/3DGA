using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellMenuUI : MonoBehaviour
{
    public Button simpleBallButton;
    public Button bouncingBallButton;
    FireTPPearl controller;
    GameObject[] pearls;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<FireTPPearl>();

        pearls = controller.pearls;

        simpleBallButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("Mode", 0);
            Debug.Log("Ball type set to << " + pearls[0].GetComponent<Pearl>().typeName + " >> ");
        });

        bouncingBallButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("Mode", 1);
            Debug.Log("Ball type set to << " + pearls[1].GetComponent<Pearl>().typeName + " >> ");
        });
        
    }

    void Update()
    {
        
    }
}
