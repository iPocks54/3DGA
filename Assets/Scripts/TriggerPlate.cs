using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour
{
    public GameObject triggerObject;
    public float triggerTimer;
    private float timer = 0;
    private bool isTrigger = false;
    private AudioSource sound;

    private void Start()
    {
        sound = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isTrigger)
            timer += Time.deltaTime;
        if (timer >= triggerTimer)
        {
            sound.Play();
            triggerObject.SetActive(true);
            isTrigger = false;
            timer = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && !isTrigger)
        {
            isTrigger = true;
            sound.Play();
            triggerObject.SetActive(false);
        }
    }
}
