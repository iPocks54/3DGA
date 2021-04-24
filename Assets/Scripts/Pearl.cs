using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pearl : MonoBehaviour
{
    GameObject tp;
    void Start()
    {
        tp = GameObject.FindGameObjectWithTag("Locomotion");
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Teleport();
    }

    void Teleport()
    {
        TeleportRequest tr = new TeleportRequest();
        tr.destinationPosition = transform.position;
        tp.GetComponent<TeleportationProvider>().QueueTeleportRequest(tr);

        Destroy(gameObject);
    }
}