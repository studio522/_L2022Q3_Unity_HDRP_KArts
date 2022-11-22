using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using extOSC;

/*******************************************************
 * Processing 3.5.4
 *******************************************************
 *
import oscP5.*;
import netP5.*;

OscP5 oscP5;
NetAddress myRemoteLocation;

void setup()
{
    size(400, 400);
    frameRate(25);
    oscP5 = new OscP5(this, 7000);

    myRemoteLocation = new NetAddress("127.0.0.1", 7001);
}


void draw()
{
    background(0);
}

void mousePressed()
{

    OscMessage myMessage = new OscMessage("/example/7/");

    myMessage.add(frameCount); 
    println("send: " + frameCount);
    myMessage.add("hihi"); 
    println("send: " + "hihi");

    oscP5.send(myMessage, myRemoteLocation);
}


void oscEvent(OscMessage theOscMessage)
{
    println("### received an osc message.");
    println("addrpattern: " + theOscMessage.addrPattern());
    println("typetag: " + theOscMessage.typetag());
    String firstValue = theOscMessage.get(0).stringValue();  // get the first osc argument
    float secondValue = theOscMessage.get(1).floatValue(); // get the second osc argument
                                                           //String thirdValue = theOscMessage.get(2).stringValue(); // get the third osc argument
                                                           //print("### received an osc message /test with typetag ifs.");
    println("values: " + firstValue + ", " + secondValue);
}

*******************************************************/

public class OSC_Controller : MonoBehaviour
{
    private OSCTransmitter Transmitter;
    private OSCReceiver Receiver;

    private const string OSCAddress = "/example/7/"; // Also, you cam use mask in address: /example/*/

    //public Text OscInText;
    //public Text OscOutText;

    void Start()
    {
        // Creating a transmitter.
        Transmitter = gameObject.AddComponent<OSCTransmitter>();

        // Set remote host address.
        Transmitter.RemoteHost = "127.0.0.1";

        // Set remote port;
        Transmitter.RemotePort = 7001;

        // Creating a receiver.
        Receiver = gameObject.AddComponent<OSCReceiver>();

        // Set local port.
        Receiver.LocalPort = 7000;

        // Bind "MessageReceived" method to special address.
        Receiver.Bind(OSCAddress, ReceiveMessage);
    }


    void ReceiveMessage(OSCMessage message)
    {
        //Debug.Log(message);
        // Create match pattern (For bool values you can use True or False ValueType)
        var matchPattern = new OSCMatchPattern(
                                               //OSCValueType.Int    // Int
                                               //OSCValueType.String // String
                                                                   //OSCValueType.Float // String
                                                                   //OSCValueType.True,   // Bool
                                                                   //OSCValueType.False
                                                OSCValueType.Float
                                               );

        // Check match pattern
        if (message.IsMatch(matchPattern))
        {
            // Correct message
            Debug.Log("We got a correct message! Yeah! Maybe you want parse it?");
        }
        else
        {
            // Wrong message
            Debug.Log("Oh, no! It's a wrong message!");
        }

        print("message:" + message);
        print("Address:" + message.Address);
        print("Float Value:" + message.Values[0].FloatValue);
        //print("String Value:" + message.Values[1].StringValue);

        //string UIText = message.Values[0].IntValue + "\n" + message.Values[1].StringValue;
        //OscInText.GetComponent<Text>().text = UIText;
    }

    public void TransmitMessage()
    {
        if (Transmitter == null) return;

        // Create message
        var message = new OSCMessage(OSCAddress);
        //string msg = OscOutText.GetComponent<Text>().text;
        //message.AddValue(OSCValue.String(msg));     // string
        //message.AddValue(OSCValue.Float(Random.Range(0f, 1f))); // float

        // Send message
        Transmitter.Send(message);

    }
}
