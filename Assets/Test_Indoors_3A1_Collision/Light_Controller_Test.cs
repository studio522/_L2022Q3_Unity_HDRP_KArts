using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Light_Controller_Test : MonoBehaviour
{
    
    //Light MyLight;
    //LightingProperty MyLight;
    // Start is called before the first frame update
    void Start()
    {
        //MyLight = GetComponent<Light>();
        //print("MyLight.spotAngle:" + MyLight.spotAngle);
        GetComponent<HDAdditionalLightData>().SetSpotAngle(10f); //set
        //print("MyLight.spotAngle:" + MyLight.spotAngle);
       
        //print(GetComponent<HDAdditionalLightData>().aspectRatio);
        GetComponent<HDAdditionalLightData>().aspectRatio = 5f; //set
        //print(GetComponent<HDAdditionalLightData>().aspectRatio);

        print(GetComponent<HDAdditionalLightData>().intensity);
        GetComponent<HDAdditionalLightData>().intensity = 5000f; //set
        print(GetComponent<HDAdditionalLightData>().intensity);

        print(GetComponent<HDAdditionalLightData>().luxAtDistance);
        GetComponent<HDAdditionalLightData>().luxAtDistance = 4f; //set
        print(GetComponent<HDAdditionalLightData>().luxAtDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
