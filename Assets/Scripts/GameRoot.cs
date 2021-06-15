
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameRoot : MonoBehaviour
{

    public Slider volumeSlider;

    public Toggle muteToggle;

    public Text timerText;

    private float timer = 60f;

    private bool timerOn = false;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener((arg0 =>AudioMgr.Instance.SetAudio(arg0)));
        muteToggle.onValueChanged.AddListener((arg0 => AudioMgr.Instance.SetAudio(!arg0)));

    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timer -= Time.deltaTime;
            if (timer <=0)
            {
                timer = 0;
            }
            timerText.text = Convert.ToInt32(timer).ToString();
        }
    }

    public void StartGame()
    {
        //Debug.Log("Start Game!!!");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // Debug.Log("Quit Game!!!");
#if UNITY_EDITOR    //在编辑器模式下
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void StartTimer()
    {
        timerOn = true;
    }

    public void StopTimer()
    {
        timerOn = false;
    }

    public void ResetTimer()
    {
        timer = 60f;
        timerText.text = Convert.ToInt32(timer).ToString();
    }

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
