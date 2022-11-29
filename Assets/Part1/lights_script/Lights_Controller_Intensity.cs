using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;


public class Lights_Controller_Intensity : MonoBehaviour
{
    public OSC osc;
    public string OSCAddr = "/hdlight/Intensity/1";
    float intensity;

    void Start()
    {
        // OSC "/hdlight/1/intensity/" + float
        GetComponent<HDAdditionalLightData>().intensity = intensity;
        osc.SetAddressHandler(OSCAddr, OnReceiveCube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setIntensity(float intensity)
    {
        GetComponent<HDAdditionalLightData>().intensity = intensity;
    }

    void OnReceiveCube(OscMessage message)
    {
        float intensity = message.GetFloat(0);
        print("OSC In:" + intensity);
        setIntensity(intensity);
    }
}
