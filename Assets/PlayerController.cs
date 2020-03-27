using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rgbody;
    public float walkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rgbody.AddForce(0,0,z*walkSpeed);
    }
}
