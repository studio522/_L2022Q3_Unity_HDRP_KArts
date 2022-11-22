using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intensity_Controller : MonoBehaviour
{
    public Material Mat;
    float intensity;
    Color EmissiveColor;
    public OSC osc;
    public string OSCAddr = "/example/7/";

    void Start()
    {
        EmissiveColor = Mat.GetColor("_EmissiveColor");
        osc.SetAddressHandler(OSCAddr, OnReceiveCube);
    }


    void Update()
    {
        ////////////////////////////////////////
        /// Test
        ////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            intensity = 0.0f;
            print(intensity);
            setIntensity(intensity);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            intensity = 12.0f;
            print(intensity);
            setIntensity(intensity);
        }
        
    }

    void setIntensity(float intensity)
    {
        Mat.SetFloat("_EmissiveIntensity", intensity);
        Color emissiveColor = EmissiveColor;
        Mat.SetColor("_EmissiveColor", emissiveColor * intensity);
    }

    void OnReceiveCube(OscMessage message)
    {
        float intensity = message.GetFloat(0);
        print("OSC In:" + intensity);
        setIntensity(intensity);
    }

}