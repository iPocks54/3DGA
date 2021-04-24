using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRespawn : MonoBehaviour
{
    GameObject player;
    public Transform refPos;
    Vector3 respawnPos;
    public float offsetFall = -15f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawnPos = refPos.position;
    }

    void Update()
    {
        if (player.transform.position.y < offsetFall)
        {
            player.transform.position = respawnPos;
        }
    }
}
