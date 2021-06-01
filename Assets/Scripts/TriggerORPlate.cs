using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerORPlate : MonoBehaviour
{
    public GameObject wallOne;
    public GameObject wallTwo;
    public float moveSize;
    private bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isPressed = true;
            wallOne.transform.Translate(Vector3.up * moveSize);
            wallTwo.transform.Translate(Vector3.down * moveSize);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isPressed = false;
            wallTwo.transform.Translate(Vector3.up * moveSize);
            wallOne.transform.Translate(Vector3.down * moveSize);
        }
    }
}
