using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Controller : MonoBehaviour
{
    public FloatingObjectsContainer_Controller ContainerScript;

    Material LightMat;
    Color EmissiveColor;
    public float intensity = 0f;
    float timer = 0;
    float interval = 2f; //seconds
    float objects = 0;
    float timeLimit = 0; //seconds


    // Start is called before the first frame update
    void Start()
    {
        LightMat = GetComponent<Renderer>().material;
        EmissiveColor = new Color(1f, 0.9358803f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        intensity += Time.deltaTime;
        timeLimit += Time.deltaTime;
        if (timer > interval)
        {
            ContainerScript.ActivateChild();
            timer = 0;
        }

        intensity = Mathf.Clamp(intensity, 0f, 200f);
        SetIntensity(Mathf.Pow(intensity, 2));
        if(timeLimit > interval * 10)
        {
           foreach(Transform Child in ContainerScript.transform)
            {
                Child.GetComponent<FloatingObjects_Controller>().isClingToTheWall = true;
            }
        }
    }

    void SetIntensity(float intensity)
    {
        LightMat.SetFloat("_EmissiveIntensity", intensity);
        LightMat.SetColor("_EmissiveColor", EmissiveColor * intensity);
        print(intensity);
    }
}
