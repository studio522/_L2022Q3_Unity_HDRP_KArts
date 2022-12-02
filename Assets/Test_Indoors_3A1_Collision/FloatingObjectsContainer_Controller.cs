using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectsContainer_Controller : MonoBehaviour
{
    public OSC osc;

    int numOfObjects = 9;
    int childIndex = 0;

    void Start()
    {
        
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        
        osc.SetAddressHandler("/light/create", OnReceiveActivateChild);
        osc.SetAddressHandler("/light/wall", OnReceiveClingToTheWall);
    }


    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateChild();
        }
        */
    }

    public void OnReceiveActivateChild(OscMessage message)
    {
        int index = message.GetInt(0);
        transform.GetChild(index).gameObject.SetActive(true);
    }

    public void OnReceiveClingToTheWall(OscMessage message)
    {
        //int index = message.GetInt(0);
        //transform.GetChild(index).GetComponent<FloatingObjects_Controller>().isClingToTheWall = true;
        foreach (Transform Child in transform)
        {
            Child.GetComponent<FloatingObjects_Controller>().isClingToTheWall = true;
        }
    }

    /*
    public void ActivateChild()
    {
        if(childIndex < transform.childCount)
        {
            transform.GetChild(childIndex).gameObject.SetActive(true);
            childIndex++;
        }
    }
    */
}
