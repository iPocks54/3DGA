using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLvl : MonoBehaviour
{
    public int collectibleNbr;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pearl"))
        {
            Application.Quit();
            print("END OF THE LEVEL");
        }
    }
}
