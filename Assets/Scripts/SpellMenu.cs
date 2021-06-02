using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


public class SpellMenu : MonoBehaviour
{
    private ActionBasedController controller;
    public GameObject menu;
    private float closeTimer;
    private float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        controller = GetComponent<ActionBasedController>();
        //controller.rotateAnchorAction.action.performed += MenuAction_performed;
        //controller.translateAnchorAction.action.performed += MenuAction_performed;
        controller.selectAction.action.performed += Action_performed;
    }

    private void Update() {
        if (closeTimer > 0)
        {
            if (Time.timeSinceLevelLoad - currentTime >= closeTimer)
                menu.SetActive(false);
        }
        
    }

    private void OpenMenu()
    {
        Debug.Log("Touchpad pressed");
        menu.SetActive(true);
        closeTimer = 2f;
        currentTime = Time.timeSinceLevelLoad;
    }
    private void MenuAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        menu.SetActive(true);
        closeTimer = 2f;
        currentTime = Time.timeSinceLevelLoad;
    }
    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        menu.SetActive(!menu.activeInHierarchy);
    }
}
