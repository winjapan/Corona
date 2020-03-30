using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rgbody;
    public float walkSpeed;
    private Vector3 PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GetComponent<Transform>().position;
        rgbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rgbody.velocity = new Vector3(x * walkSpeed, 0, z * walkSpeed);

        Vector3 diff = transform.position - PlayerPos;

        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
        PlayerPos = transform.position;
    }
}
