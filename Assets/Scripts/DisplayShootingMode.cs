using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class DisplayShootingMode : MonoBehaviour
{
    private ActionBasedController controller;
    TMP_Text shootingModeText;
    GameObject[] p;
    void Start()
    {
        shootingModeText = GetComponent<TMP_Text>();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<ActionBasedController>();
        p = controller.GetComponent<FireTPPearl>().pearls;

    }

    void Update()
    {
        shootingModeText.text = p[PlayerPrefs.GetInt("Mode")].GetComponent<Pearl>().typeName;
    }
}
