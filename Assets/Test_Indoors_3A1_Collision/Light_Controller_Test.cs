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
        GetComponent<HDAdditionalLightData>().SetSpotAngle(10f); // OSC "/hdlight/1/spotangle/" + float
        //print("MyLight.spotAngle:" + MyLight.spotAngle);
       
        //print(GetComponent<HDAdditionalLightData>().aspectRatio);
        GetComponent<HDAdditionalLightData>().aspectRatio = 5f; // OSC "/hdlight/1/aspectratio/" + float
        //print(GetComponent<HDAdditionalLightData>().aspectRatio);

        print(GetComponent<HDAdditionalLightData>().intensity);
        GetComponent<HDAdditionalLightData>().intensity = 5000f; // OSC "/hdlight/1/intensity/" + float
        print(GetComponent<HDAdditionalLightData>().intensity);

        print(GetComponent<HDAdditionalLightData>().luxAtDistance);
        GetComponent<HDAdditionalLightData>().luxAtDistance = 4f; // OSC "/hdlight/1/luxat/" + float
        print(GetComponent<HDAdditionalLightData>().luxAtDistance);

        // OSC "/hdlight/area1/luxat/" + float
        // OSC "/hdlight/area2/luxat/" + float
        // OSC "/hdlight/spot1/luxat/" + float
        // OSC "/hdlight/spot2/luxat/" + float
        // OSC "/hdlight/spot3/luxat/" + float
        // OSC "/hdlight/spot4/luxat/" + float
        // OSC "/hdlight/spot5/luxat/" + float
        // OSC "/hdlight/spot6/luxat/" + float
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
