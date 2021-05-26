using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pearl : MonoBehaviour
{
    protected GameObject tp;
    public string typeName;
    public GameObject TP_animation;
    public GameObject Fire_animation;
    
    protected void Start()
    {
        tp = GameObject.FindGameObjectWithTag("Locomotion");

    }

    private void Awake()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Teleport();
    }

    public virtual void Teleport()
    {
        TeleportRequest tr = new TeleportRequest();
        tr.destinationPosition = transform.position;
        tp.GetComponent<TeleportationProvider>().QueueTeleportRequest(tr);

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        TP_animation.transform.position = transform.position;
        GameObject clone = TP_animation;
        clone = Instantiate(clone) as GameObject;
        Destroy(clone, 2);
    }
}
