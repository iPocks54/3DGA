using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Repress_Pearl : Pearl
{
    private ActionBasedController controller;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<ActionBasedController>();
        controller.activateAction.action.performed += Action_performed;
        tp = GameObject.FindGameObjectWithTag("Locomotion");
        controller.GetComponent<FireTPPearl>().DisableFire();
    }

    void Update()
    {
        
    }

    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Repress();
    }

    private void OnCollisionEnter(Collision collision)
    {
        return;
    }

    void Repress()
    {
        controller.activateAction.action.performed -= Action_performed;
        controller.GetComponent<FireTPPearl>().EnableFire();
        base.Teleport();
    }
}
