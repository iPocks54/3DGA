using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLvl : MonoBehaviour
{
    public int collectibleNbr;
    public int sceneNbr = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pearl"))
        {
            SceneManager.LoadScene(sceneNbr);
            //Application.Quit();
            print("END OF THE LEVEL");
        }
    }
}
