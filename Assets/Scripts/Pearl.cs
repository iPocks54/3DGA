using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pearl : MonoBehaviour
{
    GameObject offset;
    GameObject player;
    GameObject camera;
    GameObject tp;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = GameObject.FindGameObjectWithTag("CameraOffset");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        tp = GameObject.FindGameObjectWithTag("Locomotion");
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        TeleportRequest tr = new TeleportRequest();
        tr.destinationPosition = transform.position;
        tp.GetComponent<TeleportationProvider>().QueueTeleportRequest(tr);

        Destroy(gameObject);
    }
}
