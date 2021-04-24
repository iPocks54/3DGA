using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BouncingPearl : MonoBehaviour
{
    GameObject tp;
    public int nbBounce = 1;
    void Start()
    {
        tp = GameObject.FindGameObjectWithTag("Locomotion");
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (nbBounce != 0)
            nbBounce -= 1;
        else
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
