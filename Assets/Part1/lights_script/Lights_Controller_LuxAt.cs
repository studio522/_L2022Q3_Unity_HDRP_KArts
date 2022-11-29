using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;


public class Lights_Controller_LuxAt : MonoBehaviour
{
    public OSC osc;
    public string OSCAddr = "/hdlight/LuxAt/1";
    float luxAt;

    void Start()
    {
        // OSC "/hdlight/1/luxat/" + float
        GetComponent<HDAdditionalLightData>().luxAtDistance = luxAt;
        osc.SetAddressHandler(OSCAddr, OnReceiveCube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setLuxAt(float luxAt)
    {
        GetComponent<HDAdditionalLightData>().luxAtDistance = luxAt;
    }

    void OnReceiveCube(OscMessage message)
    {
        float luxAt = message.GetFloat(0);
        print("OSC In:" + luxAt);
        setLuxAt(luxAt);
    }
}
