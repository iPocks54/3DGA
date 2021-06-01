using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour
{
    public GameObject triggerObject;
    public float triggerTimer;
    private float timer = 0;
    private bool isTrigger = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isTrigger)
            timer += Time.deltaTime;
        if (timer >= triggerTimer)
        {
            triggerObject.SetActive(true);
            timer = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
            triggerObject.SetActive(false);
        }
    }
}
