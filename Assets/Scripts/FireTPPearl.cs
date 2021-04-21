using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireTPPearl : MonoBehaviour
{
    private ActionBasedController controller;
    public Transform rightHand;
    public GameObject pearl;
    Vector3 throwing_position;
    public float force = 200f;
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.activateAction.action.performed += Action_performed;
        rightHand = GetComponent<Transform>();
        pearl.GetComponent<Rigidbody>();
        throwing_position = rightHand.GetComponent<Transform>().position;
    }

    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Fire();
    }

    void Update()
    {

    }

    void Fire()
    {
        GameObject nPearl = Instantiate(pearl, rightHand.position, Quaternion.identity);
        nPearl.GetComponent<Rigidbody>().AddForce(rightHand.transform.forward * force);
    }
}
