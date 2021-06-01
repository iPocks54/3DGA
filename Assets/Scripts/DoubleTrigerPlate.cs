using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTrigerPlate : MonoBehaviour
{
    public GameObject triggerObject;
    public GameObject triggerObject2;
    private bool isTrigger = false;

    private void Start()
    {
        triggerObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
            triggerObject.SetActive(true);
            triggerObject2.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = false;
            triggerObject.SetActive(false);
            triggerObject2.SetActive(true);
        }
    }
}
