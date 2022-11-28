using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectsContainer_Controller : MonoBehaviour
{
    int numOfObjects = 9;
    int childIndex = 0;

    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateChild();
        }
    }

    public void ActivateChild()
    {
        if(childIndex < transform.childCount)
        {
            transform.GetChild(childIndex).gameObject.SetActive(true);
            childIndex++;
        }         
    }
}
