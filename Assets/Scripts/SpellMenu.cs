using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SpellMenu : MonoBehaviour
{
    private ActionBasedController controller;
    public Canvas menu;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MENU VA ETRE DISABLE");
        menu.enabled = false;
        controller = GetComponent<ActionBasedController>();
        controller.selectAction.action.performed += Action_performed;
    }

    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("LE BOUTON A ETE APPUE LA BON SANG");
        menu.enabled = !menu.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
