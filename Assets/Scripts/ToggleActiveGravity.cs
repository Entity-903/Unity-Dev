using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhateverIDK : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = !rb.useGravity;

            if (!rb.useGravity)
            {
                Vector3 temp = rb.velocity;
                temp.y = 0f;
                rb.velocity = temp;
            }
        }
    }
}
