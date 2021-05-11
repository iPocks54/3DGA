using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Collectibles : MonoBehaviour
{
    public Text timeText;
    private int collectibleNbr = 0;

    void Start()
    {
        //timeText.text = "0 collectible";
    }

    void Update()
    {
       // timeText.text = collectibleNbr + " collectibles";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            print("AH OUI CA JAIME BIEN LO");
            collectibleNbr++;
            Destroy(collision.gameObject);
        }
    }
}
