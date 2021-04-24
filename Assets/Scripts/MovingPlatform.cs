using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingPlatform : MonoBehaviour
{
    public float distance = 3;

    public float xmove = 0;
    public float ymove = 0.1f;
    public float zmove = 0;
    public float movingTime;
    private float time = 0;
    private Transform pos;
    private Vector3 startingPos;
    // Start is called before the first frame update

        //CODE DEGEUX MARCHE QUE POUR Y ACTUALLY ^^
    void Start()
    {
        pos = this.transform;
        startingPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (this.transform.position.y >= startingPos.y + distance)
        {
            xmove = -xmove;
            ymove = -ymove;
            zmove = -zmove;
            time = 0;
        }
        if (this.transform.position.y <= startingPos.y - distance)
        {
            xmove = -xmove;
            ymove = -ymove;
            zmove = -zmove;
            time = 0;
        }
        pos.Translate(xmove, ymove, zmove);
    }
}
