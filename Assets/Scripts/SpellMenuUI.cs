using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellMenuUI : MonoBehaviour
{
    public Button simpleBallButton;
    public Button bouncingBallButton;
    // Start is called before the first frame update
    void Start()
    {
        simpleBallButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("Mode", 0);
            Debug.Log("Ball type set to << SIMPLE >> ");
        });

        bouncingBallButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("Mode", 1);
            Debug.Log("Ball type set to << BOUNCING >> ");
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
