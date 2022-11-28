using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjects_Controller : MonoBehaviour
{
    public Transform Destination;
    Vector3 OriginalPos;
    Vector3 CenterPos;
    Rigidbody rb;
    public float bounceSpeed_object = 0.05f;
    public float bounceSpeed_wall = 0.001f;

    public bool isClingToTheWall = false;
    //public Material LightMat_On;
    Material LightMat;
    Color EmissiveColor;
    public float intensity = 200f;

    void Start()
    {
        OriginalPos = new Vector3(0, 2f, 0);
        CenterPos = new Vector3(0, 5, 0);
        rb = GetComponent<Rigidbody>();

        transform.position = OriginalPos;
        rb.velocity = Random.insideUnitSphere * 0.5f;

        LightMat = transform.GetChild(0).GetComponent<Renderer>().material;
        //EmissiveColor = LightMat.GetColor("_EmissiveColorMap");
        EmissiveColor = new Color(1f, 0.9358803f, 0f, 1f);
    }

    void Update()
    {
        if (!isClingToTheWall)
        {
            float distToCenter = Vector3.Distance(transform.position, OriginalPos);
            if (distToCenter > 10f)
            {
                rb.MovePosition(OriginalPos);
                rb.velocity = Random.insideUnitSphere * 0.5f;
                rb.angularVelocity = Vector3.zero;
            }
        }
        else
        {
            ClingToTheWall();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isClingToTheWall = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isClingToTheWall)
        {
            if (collision.gameObject.tag == "wall")
            {
                print(gameObject.name + " hit wall");
                print(gameObject.name + " move to center start");
                rb.velocity = (CenterPos + Random.insideUnitSphere * 4 - transform.position).normalized * bounceSpeed_wall;
            }
            else
            {
                rb.velocity = Random.insideUnitSphere * bounceSpeed_object;
            }
        }
    }

    void ClingToTheWall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = Vector3.Lerp(transform.position, Destination.position, 0.01f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Destination.rotation, 0.01f);
        float dist = Vector3.Distance(transform.position, Destination.position);
        if(dist < 2f)
        {
            SetIntensity(intensity);
        }
    }

    void SetIntensity(float intensity)
    {
        LightMat.SetFloat("_EmissiveIntensity", intensity);
        LightMat.SetColor("_EmissiveColor", EmissiveColor * intensity);
        print("mat changed");
    }
}
