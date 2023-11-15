using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStickThrust : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Thrust();
        }
    }

    void Thrust()
    {
        // Trigger the thrust animation
        animator.SetTrigger("Thrust");
    }
}
