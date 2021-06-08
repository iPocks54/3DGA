using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class FireTPPearl : MonoBehaviour
{
    private ActionBasedController controller;
    public Transform rightHand;
    public GameObject[] pearls;
    public float force = 200f;
    public GameObject jauge;
    private float heating = 0;
    Vector3 firePos;
    Vector3 jaugePos;
    CooldownTimer cd;

    public AudioSource fireSound;
    public AudioSource errorSound;
    public AudioSource overHeatSound;

    public ParticleSystem overHeatParticles;
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.activateAction.action.performed += Action_performed;
        rightHand = GetComponent<Transform>();
        jaugePos = jauge.GetComponent<Transform>().localPosition;
        fireSound = fireSound.GetComponent<AudioSource>();
        errorSound = errorSound. GetComponent<AudioSource>();
        overHeatSound = overHeatSound.GetComponent<AudioSource>();
        overHeatParticles = overHeatParticles.GetComponent<ParticleSystem>();
            
        cd = new CooldownTimer(2);
        cd.TimeRemaining = 0;

        foreach (GameObject o in pearls)
            o.GetComponent<Rigidbody>();

        PlayerPrefs.SetInt("Mode", 0);
        PlayerPrefs.SetInt("AllModes", pearls.Length);
    }

    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (heating != 0.99f)
            Fire(pearls[PlayerPrefs.GetInt("Mode")]);
        else if (heating >= 0.99f)
            errorSound.Play();
    }

    void Update()
    {
        jaugePos.z = 1 - heating;
        jauge.GetComponent<Transform>().localPosition = jaugePos;
        cd.Update(Time.deltaTime);
        HeatingManager();
        print(overHeatParticles.isPlaying);

    }

    void Fire(GameObject pearl)
    {
        fireSound.Play();

        firePos = GameObject.FindGameObjectWithTag("FirePosition").transform.position;

        GameObject nPearl = Instantiate(pearl, firePos, Quaternion.identity);
        nPearl.GetComponent<Rigidbody>().AddForce(rightHand.transform.forward * force);
        Destroy(nPearl, 15);

        GameObject shot = nPearl.GetComponent<Pearl>().Fire_animation;
        shot = Instantiate(shot, firePos, Quaternion.identity);
        shot.transform.rotation = rightHand.transform.rotation;
        Destroy(shot, 2);

        heating += nPearl.GetComponent<Pearl>().heatValue;

        if (heating >= 1)
        {
            heating = 0.99f;
            overHeatSound.Play();
        }
        cd.Start();
    }

    public void DisableFire()
    {
        controller.activateAction.action.performed -= Action_performed;
    }

    public void EnableFire()
    {
        controller.activateAction.action.performed += Action_performed;
    }

    private void HeatingManager()
    {
        if (!cd.IsActive && heating > 0)
        {
            heating -= 0.2f * Time.deltaTime;
        }

        if (heating < 0)
            heating = 0;

        if (heating >= 0.99f && !overHeatParticles.isPlaying)
            overHeatParticles.Play();
        else if (heating < 0.99f && overHeatParticles.isPlaying)
            overHeatParticles.Stop();
    }
}
