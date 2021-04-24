using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    BoxCollider col;
    Transform cam;
    void Start()
    {
        col = GetComponent<BoxCollider>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        Vector3 pos = new Vector3(cam.localPosition.x, 0.66f, cam.localPosition.z);
        col.center = pos;
    }
}
