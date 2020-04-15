using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopMotion : MonoBehaviour
{
    private Animator animator;
    public InfectedpersonController infectedperson;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //animator.SetTrigger("Stop");
        //animator.SetBool("run", false);
        //Invoke("LostTime", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Don'tTouchMe")
        {

            //rgbody.AddForce(100, 0, 100);
            animator.SetBool("run", false);
           
            infectedperson.enabled = false;
            agent.enabled = false;
            StartCoroutine(Stop());
            Debug.Log(col.gameObject.tag);

        }
        //Debug.Log(this.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Immunity")
        {
            Invoke("Death", 1);

        }
    }

   IEnumerator Stop()
    {
       
        animator.SetBool("Down",true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("Down", false);
        animator.SetTrigger("WakeUp");
        yield return new WaitForSeconds(0.2f);
        infectedperson.enabled = true;
        this.enabled = false;
        agent.enabled = true;
        animator.ResetTrigger("WakeUp");
        animator.SetBool("run", true);
    }
    void Death()
    {
        Destroy(this.gameObject);
    }
  

}
