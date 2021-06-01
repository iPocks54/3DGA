using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerORPlate : MonoBehaviour
{
    public GameObject wallOne;
    public GameObject wallTwo;
    public float moveSize;
    public bool timer = false;
    private bool isTrigger = false;
    public float openTimer = 5f;
    private float time = 0f;

    void Update()
    {
        if (timer && isTrigger)
            time += Time.deltaTime;
        if (timer && time >= openTimer)
        {
            leavePlatform();
            time = 0;
        }
        
    }

    private void leavePlatform()
    {
        isTrigger = false;
        wallTwo.transform.Translate(Vector3.up * moveSize);
        wallOne.transform.Translate(Vector3.down * moveSize);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
            wallOne.transform.Translate(Vector3.up * moveSize);
            wallTwo.transform.Translate(Vector3.down * moveSize);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && !timer)
            leavePlatform();
    }
}
