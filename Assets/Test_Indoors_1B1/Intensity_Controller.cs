using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intensity_Controller : MonoBehaviour
{
    public Material Mat;
    Material CubeMaterial;
    Shader CubeShader;
    float intensity;
    Color EmissiveColor;
    void Start()
    {
        CubeShader = Shader.Find("HDRP/Lit");
        EmissiveColor = Mat.GetColor("_EmissiveColor");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            intensity = 0.0f;
            print(intensity);
            setIntensity(intensity);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            intensity = 12.0f;
            print(intensity);
            setIntensity(intensity);
        }
        
    }

    void setIntensity(float intensity)
    {
        Mat.SetFloat("_EmissiveIntensity", intensity);
        //float emissiveIntensity = 10;
        Color emissiveColor = EmissiveColor;
        Mat.SetColor("_EmissiveColor", emissiveColor * intensity);
        //m_EmissiveObject.GetComponent<Renderer>().material.SetColor("_EmissiveColor", emissiveColor * emissiveIntensity);
    }
}
