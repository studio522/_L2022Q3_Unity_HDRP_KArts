using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;


public class Lights_Controller_AspectRatio : MonoBehaviour
{
    public OSC osc;
    public string OSCAddr = "/hdlight/aspectRatio/1";
    float aspectRatio;

    void Start()
    {
        // OSC "/hdlight/1/aspectratio/" + float
        GetComponent<HDAdditionalLightData>().aspectRatio = aspectRatio;
        osc.SetAddressHandler(OSCAddr, OnReceiveCube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setAspectRatio(float aspectRatio)
    {
        GetComponent<HDAdditionalLightData>().aspectRatio = aspectRatio;
    }

    void OnReceiveCube(OscMessage message)
    {
        float aspectRatio = message.GetFloat(0);
        print("OSC In:" + aspectRatio);
        setAspectRatio(aspectRatio);
    }
}
