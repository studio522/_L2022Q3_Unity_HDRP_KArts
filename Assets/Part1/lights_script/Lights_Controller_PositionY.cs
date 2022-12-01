using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;


public class Lights_Controller_PositionY : MonoBehaviour
{
    public OSC osc;
    public string OSCAddr = "/positionY/1";
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

    void setPosition(float YPos)
    {
        transform.position = Pos;
        Pos = new Vector3 (transform.position.x, YPos, transform.position.z);
    }

    void OnReceiveCube(OscMessage message)
    {
        float YPos = message.GetFloat(0);
        print("OSC In:" + YPos);
        setPosition(YPos);
    }
}
