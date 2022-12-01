using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;


public class Lights_Controller_PositionX : MonoBehaviour
{
    public OSC osc;
    public string OSCAddr = "/positionX/1";
    Vector3 Pos;

    void Start()
    {
        transform.position = Pos;
        osc.SetAddressHandler(OSCAddr, OnReceiveCube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setPosition(float XPos)
    {
        transform.position = Pos;
        Pos = new Vector3 (XPos, transform.position.y, transform.position.z);
    }

    void OnReceiveCube(OscMessage message)
    {
        float XPos = message.GetFloat(0);
        print("OSC In:" + XPos);
        setPosition(XPos);
    }
}
