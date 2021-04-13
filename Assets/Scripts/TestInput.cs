using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TestInput : MonoBehaviour
{
    private ActionBasedController controller;
    void Start()
    {
        controller = GetComponent<ActionBasedController>();

        bool isPressed = controller.selectAction.action.ReadValue<bool>();

        controller.selectAction.action.performed += Action_performed;
    }

    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Pressed");
    }

    void Update()
    {
        
    }
}
