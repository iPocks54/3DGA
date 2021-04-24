using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireTPPearl : MonoBehaviour
{
    private ActionBasedController controller;
    public Transform rightHand;
    public GameObject[] pearls;
    Vector3 throwing_position;
    public float force = 200f;
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.activateAction.action.performed += Action_performed;
        rightHand = GetComponent<Transform>();
        throwing_position = rightHand.GetComponent<Transform>().position;

        foreach (GameObject o in pearls)
            o.GetComponent<Rigidbody>();

        PlayerPrefs.SetInt("Mode", 0);
        PlayerPrefs.SetInt("AllModes", pearls.Length);
    }

    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Fire(pearls[PlayerPrefs.GetInt("Mode")]);
    }

    void Update()
    {

    }

    void Fire(GameObject pearl)
    {
        Vector3 firePos = rightHand.position;
        firePos.y += 0.2f;

        GameObject nPearl = Instantiate(pearl, firePos, Quaternion.identity);
        nPearl.GetComponent<Rigidbody>().AddForce(rightHand.transform.forward * force);
        Destroy(nPearl, 15);

    }
}
