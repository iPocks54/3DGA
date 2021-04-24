using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchMode : MonoBehaviour
{
    private ActionBasedController controller;

    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.activateAction.action.performed += Action_performed;
    }

    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        PlayerPrefs.SetInt("Mode", PlayerPrefs.GetInt("Mode") + 1);

        if (PlayerPrefs.GetInt("Mode") >= PlayerPrefs.GetInt("AllModes"))
            PlayerPrefs.SetInt("Mode", 0);
    }

    void Update()
    {
        
    }
}
