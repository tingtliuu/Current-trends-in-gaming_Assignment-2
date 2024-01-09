using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holescript : MonoBehaviour
{

    public GameObject board;
    public PhysicMaterial icePhysics;
    public PhysicMaterial slimePhysics;
    public Material iceMaterial;
    public Material slimeMaterial;
    public AudioSource icyWind;
    public AudioSource slimeSound;


    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlueBall"){
            Destroy(other.gameObject);

            board.GetComponent<Collider>().material = icePhysics;
            board.GetComponent<Renderer>().material.color = iceMaterial.color;
            icyWind.Play();

        }
        if (other.tag == "GreenBall")
        {
            Destroy(other.gameObject);

            board.GetComponent<Collider>().material = slimePhysics;
            board.GetComponent<Renderer>().material.color = slimeMaterial.color;
            slimeSound.Play();

        }

    }

}
