using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Controller : MonoBehaviour
{
    // use OSC
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
        // OSC "/light/create/" + none (int)
        if (timer > interval)
        {
            ContainerScript.ActivateChild(); 
            timer = 0;
        }

        // OSC "/light/cube/" + float
        intensity = Mathf.Clamp(intensity, 0f, 200f);  
        SetIntensity(Mathf.Pow(intensity, 2)); // <-- OSC float value

        // OSC "/light/wall/" + int (0~9)
        if (timeLimit > interval * 10)
        {
           foreach(Transform Child in ContainerScript.transform)
            {
                Child.GetComponent<FloatingObjects_Controller>().isClingToTheWall = true;
            }
        }

        // Part2
        // Camera fade out (color - "osc" -> gray scale -"osc"-> color)
        // OSC for Cam "/cam/gray", "/cam/color/"

        // Part3
        // Camera fade out (color -"osc"-> black out)
        // OSC for Cam "/cam/blackout"
    }

    void SetIntensity(float intensity)
    {
        LightMat.SetFloat("_EmissiveIntensity", intensity);
        LightMat.SetColor("_EmissiveColor", EmissiveColor * intensity);
        print(intensity);
    }
}
