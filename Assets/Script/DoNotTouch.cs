using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DoNotTouch : MonoBehaviour
{
    [SerializeField]
    //public GameObject Pushaway;
    public PlayerController player;
    public Rigidbody rgbody;

    public Rigidbody rg;

    private float radius = 1000;
    private float Blowing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        Vector3 blowPos = transform.position;

        Collider[] colliders = Physics.OverlapSphere(blowPos, radius + transform.position.z *70000);
        if (col.gameObject.tag == "Dence contact")
        {
            foreach (Collider hit in colliders)
            {
                //Rigidbody rg;
                rg = hit.GetComponent<Rigidbody>();
                if (rgbody != null)
                {
                    rgbody.AddExplosionForce(Blowing, blowPos, 5000);

                }
            }
        }
        //Debug.Log(this.transform.position);
    }

   
}
