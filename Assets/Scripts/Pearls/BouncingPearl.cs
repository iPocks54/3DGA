using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BouncingPearl : Pearl
{
    public int nbBounce = 1;
    public GameObject bounce_Animation;

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (nbBounce != 0)
        {
            nbBounce -= 1;
            bounce_Animation.transform.position = transform.position;
            GameObject clone = bounce_Animation;
            clone = Instantiate(clone);
            Destroy(clone, 2);
        }
        else
            base.Teleport();
    }
}
