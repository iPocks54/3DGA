using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    public GameObject xrRig;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.rotate = cam.transform.rotate;
        //this.transform.rotate = xrRig.transform.rotate;
        //transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
        transform.LookAt(transform.position + xrRig.transform.rotation * Vector3.forward, xrRig.transform.rotation * Vector3.up);
    }
}
