using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_Intensity_Controller : MonoBehaviour
{
    public Material Mat;
    float intensity;
    Color EmissiveColor;
    public OSC osc;
    public string OSCAddr = "/light/left/7/";

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
            intensity = 0.01f;
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
        Color MinColor = new Color(0.1f, 0.1f, 0.1f);
        Color emissiveColor = EmissiveColor + MinColor;
        Mat.SetColor("_EmissiveColor", emissiveColor * intensity);
        Mat.SetColor("_EmissiveColor", EmissiveColor * intensity);
    }

    void OnReceiveCube(OscMessage message)
    {
        float intensity = message.GetFloat(0);
        print("OSC In:" + intensity);
        setIntensity(intensity);
    }

}


