using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject barriar;
    public GameObject Hand;
    private Rigidbody rgbody;
    public float walkSpeed;
    private Vector3 PlayerPos;
    public AudioSource audioSource;
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
        //Debug.Log("Corona");
        rgbody.velocity = new Vector3(x * walkSpeed, 0, z * walkSpeed);

        Vector3 diff = transform.position - PlayerPos;

        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
        PlayerPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Z))
        {
        
            //Debug.Log("aaa");
            StartCoroutine(EndAttack());

        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Immunity")
        {
            StartCoroutine(Invincible());
        }
    }

    IEnumerator Invincible()
    {
        audioSource.enabled = false;
        barriar.SetActive(true);
        yield return new WaitForSeconds(60);
        audioSource.enabled = true;
        barriar.SetActive(false);
    }

   IEnumerator EndAttack()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Don't touch me");
        Hand.SetActive(true);
        rgbody.isKinematic = true;
        yield return new WaitForSeconds(3);
        this.gameObject.layer = LayerMask.NameToLayer("Player");
        rgbody.isKinematic = false;
        Hand.SetActive(false);
       
    }
}
