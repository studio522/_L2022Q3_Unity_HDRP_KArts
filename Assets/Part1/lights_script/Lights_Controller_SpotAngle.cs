using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;


public class Lights_Controller_SpotAngle : MonoBehaviour
{
    public OSC osc;
    public string OSCAddr = "/hdlight/SpotAngle/1";
    float SpotAngle;

    void Start()
    {
        // OSC "/hdlight/1/spotangle/" + float
        GetComponent<HDAdditionalLightData>().SetSpotAngle(SpotAngle);
        osc.SetAddressHandler(OSCAddr, OnReceiveCube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setSpotAngle(float SpotAngle)
    {
        GetComponent<HDAdditionalLightData>().SetSpotAngle(SpotAngle);
    }

    void OnReceiveCube(OscMessage message)
    {
        float SpotAngle = message.GetFloat(0);
        print("OSC In:" + SpotAngle);
        setSpotAngle(SpotAngle);
    }
}
