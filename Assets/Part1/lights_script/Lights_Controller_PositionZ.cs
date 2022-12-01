using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;


public class Lights_Controller_PositionZ : MonoBehaviour
{
    public OSC osc;
    public string OSCAddr = "/positionZ/part2_";
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

    void setPosition(float ZPos)
    {
        transform.position = Pos;
        Pos = new Vector3 (transform.position.x, transform.position.y, ZPos);
    }

    void OnReceiveCube(OscMessage message)
    {
        float ZPos = message.GetFloat(0);
        print("OSC In:" + ZPos);
        setPosition(ZPos);
    }
}
