using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAnimSound : MonoBehaviour
{
    public GameObject CollectSound;
    public GameObject CollectParticles;

    void Start()
    {
        
    }

    private void OnDestroy()
    {
        if (CollectSound)
            PlayCollectSound();
        if (CollectParticles)
            PlayCollectParticles();
    }

    void PlayCollectSound()
    {
        GameObject clone = CollectSound;
        clone = Instantiate(clone);
        clone.GetComponent<AudioSource>().Play();
        Destroy(clone, 2);
    }

    void PlayCollectParticles()
    {
        CollectParticles.transform.position = transform.position;
        GameObject clone = CollectParticles;
        clone = Instantiate(clone) as GameObject;
        Destroy(clone, 2);
    }
}
