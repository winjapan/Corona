using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageHP : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rgbody;

    public Image coronaGauge;

    public GameObject SE1;
    public GameObject SE2;
    public GameObject DeathSE;
    [SerializeField]
    private int coronaHP = 100;
    public int toxicity = 1;
    public AudioClip NoTouch;
    private float timeWind;
    public float timeLaspe;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rgbody = GetComponent<Rigidbody>();
        //coronaHP = 100;
        coronaGauge.fillAmount = 1;
        timeLaspe = 15;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionStay(Collision hit)
    {

        if (hit.gameObject.CompareTag("Dense contact"))
        {

            coronaHP -= toxicity;
           ///rgbody.isKinematic = true;
            coronaGauge.fillAmount -= 0.01f;
            //audioSource.PlayOneShot(NoTouch);

            //Debug.Log(coronaHP);

        }

        if (coronaHP < 50)
        {
            //audioSource.PlayOneShot(NoTouch);
            SE1.SetActive(true);
            //Debug.Log(GameObject.Find("name"));
        }

        if (coronaHP < 25)
        {
            SE1.SetActive(false);
            SE2.SetActive(true);
        }
        if (coronaHP < 0)
        {
            SE2.SetActive(false);
            DeathSE.SetActive(true);
            coronaHP = 0;
            //Debug.Log("コロナにかかったね！");
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Artificial lung")
        {
            coronaHP += 100;
            SE1.SetActive(false);
            SE2.SetActive(false);
            coronaGauge.fillAmount += 1;
            //Debug.Log("人工肺で生き返った！");

        }

        if (coronaHP > 100)
        {
            coronaHP = 100;
        }
    }



    //private void OnCollisionEnd(Collision end)
    //{
    //    if (end.gameObject.tag == "Dense contact")
    //    {
    //        rgbody.isKinematic = false;
    //    }
    //}



}
