using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SpellMenu : MonoBehaviour
{
    private ActionBasedController controller;
    public Canvas menu;
    private float closeTimer;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        menu.enabled = false;
        controller = GetComponent<ActionBasedController>();
        controller.rotateAnchorAction.action.performed += MenuAction_performed;
        controller.translateAnchorAction.action.performed += MenuAction_performed;
        controller.selectAction.action.performed += Action_performed;
    }

    private void Update() {
        if (closeTimer > 0)
        {
            if (Time.timeSinceLevelLoad - currentTime >= closeTimer)
                menu.enabled = false;
        }
        
    }

    private void MenuAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        menu.enabled = true;
        closeTimer = 2f;
        currentTime = Time.timeSinceLevelLoad;
    }
    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        menu.enabled = !menu.enabled;
    }
}
