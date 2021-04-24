using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class FireTPPearl : MonoBehaviour
{
    private ActionBasedController controller;
    public Transform rightHand;
    public GameObject[] pearls;
    public float force = 200f;
    Vector3 firePos;
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.activateAction.action.performed += Action_performed;
        rightHand = GetComponent<Transform>();

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
        firePos = GameObject.FindGameObjectWithTag("FirePosition").transform.position;

        GameObject nPearl = Instantiate(pearl, firePos, Quaternion.identity);
        nPearl.GetComponent<Rigidbody>().AddForce(rightHand.transform.forward * force);
        Destroy(nPearl, 15);


        GameObject shot = nPearl.GetComponent<Pearl>().Fire_animation;
        shot = Instantiate(shot, firePos, Quaternion.identity);
        shot.transform.rotation = rightHand.transform.rotation;
        Destroy(shot, 2);
    }
}
