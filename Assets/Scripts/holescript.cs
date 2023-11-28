using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holescript : MonoBehaviour
{
    public GameObject dest;
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
        if (other.tag == "ball"){
          Destroy(other.gameObject);
        }

    }

}
