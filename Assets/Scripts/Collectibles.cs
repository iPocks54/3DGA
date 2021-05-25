using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Collectibles : MonoBehaviour
{
    public Text timeText;
    public int collectibleNbr = 0;
    public int collectibleNeeded = 0;
    public GameObject blackHole;

    void Start()
    {
        blackHole.SetActive(false);
        //timeText.text = "0 collectible";
    }

    void Update()
    {
        if (blackHole.active == false && collectibleNbr >= collectibleNeeded)
            blackHole.SetActive(true);
       // timeText.text = collectibleNbr + " collectibles";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            collectibleNbr++;
            Destroy(collision.gameObject);
        }
    }

    //ici que ça trigger
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Collectible"))
        {
            collectibleNbr++;
            Destroy(other.gameObject);
        }
    }
}
