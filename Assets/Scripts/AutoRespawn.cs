using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRespawn : MonoBehaviour
{
    GameObject player;
    public Transform respawnPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (player.transform.position.y < -15)
        {
            player.transform.position = respawnPos.position;
        }
    }
}
