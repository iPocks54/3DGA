using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


public class SpellMenu : MonoBehaviour
{
    private ActionBasedController controller;
    public List<Button> buttons;
    public GameObject menu;
    private List<UnityEngine.XR.InputDevice> leftHandedControllers;
    private float closeTimer;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {

        leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
        controller = GetComponent<ActionBasedController>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandedControllers);
        menu.SetActive(false);
        controller.selectAction.action.performed += Action_performed;
    }

    private void Update() {
        Vector2 axis;
        bool axisClick;
        bool axisTouch;
        
        foreach (var device in leftHandedControllers)
        {
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out axis) && (axis.x != 0 || axis.y != 0)) {
                OpenMenu();
                if (menu.activeInHierarchy && axis.y < 0.5) {
                    buttons[0].onClick.Invoke();
                }
                else if (menu.activeInHierarchy && axis.x < 0.5)
                {
                    buttons[1].onClick.Invoke();
                }
                else if (menu.activeInHierarchy && axis.y >= 0.5) {
                    buttons[2].onClick.Invoke();
                }
                else if (menu.activeInHierarchy && axis.x >= 0.5) {
                    buttons[3].onClick.Invoke();
                }
            }
            
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out axisClick) && axisClick) {
                OpenMenu();
            }

            
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out axisTouch) && axisTouch) {
                OpenMenu();
            }
        }
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
