using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InfectedpersonController : MonoBehaviour
{
    public NavMeshAgent agent;
    private Animator animator;
    public GameObject target;

    private Rigidbody rgbody;
    public StopMotion motion;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rgbody = GetComponent<Rigidbody>();
        motion = GetComponent<StopMotion>();
    }

    // Update is called once per frame
    void Update()
    {
        //float speed = 30;
        agent.destination = target.transform.position;
        animator.SetBool("run", true);
    }

    private void OnCollisionEnter(Collision other)
    {
        Vector3 blowPos = transform.position;

        //Collider[] colliders = Physics.OverlapSphere(blowPos, radius);
        if (other.gameObject.tag == "Don't Touch Me")
        {
            animator.SetBool("Down",false);
            this.enabled = false;

            agent.enabled = false;
            //Invoke("Stop", 1f);
            Debug.Log(other.gameObject.tag);
        }
     
    }
}
