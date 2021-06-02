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
    InputActionProperty m_LeftHandMoveAction;

    public InputActionProperty leftHandMoveAction
        {
            get => m_LeftHandMoveAction;
            set => SetInputActionProperty(ref m_LeftHandMoveAction, value);
        }



        void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
        {
            if (Application.isPlaying)
                property.DisableDirectAction();

            property = value;

            if (Application.isPlaying && isActiveAndEnabled)
                property.EnableDirectAction();
        }

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
        var leftHandValue = m_LeftHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
        Debug.Log(leftHandValue);
        if (leftHandValue.x != 0 || leftHandValue.y != 0)
            OpenMenu();
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
