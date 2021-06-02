using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


public class SpellMenu : MonoBehaviour
{
    private ActionBasedController controller;
    public GameObject menu;
    private float closeTimer;
    private float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        Vector2 axis;
        bool axisClick;
        bool axisTouch;
        
        var leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
        controller = GetComponent<ActionBasedController>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandedControllers);
        foreach (var device in leftHandedControllers)
        {
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out axis) && (axis.x != 0 || axis.y != 0)) {
                OpenMenu();
            }
            
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out axisClick) && axisClick) {
                OpenMenu();
            }

            
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out axisTouch) && axisTouch) {
                OpenMenu();
            }
        }
        menu.SetActive(false);
        //controller = GetComponent<ActionBasedController>();
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
