using UnityEngine;
using System.Collections;

public class Test_Receive : MonoBehaviour
{

    public OSC osc;

    void Start()
    {
        osc.SetAddressHandler("/example/7/", OnReceiveCube);
    }

    void OnReceiveCube(OscMessage message)
    {
        float intensity = message.GetFloat(0);
        print("OSC In:" + intensity);
    }
}
