﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject Count;
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
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("GameDirector").GetComponent<AbiganCountDirector>().ColAbigan();
            Destroy(this.gameObject);
            //Debug.Log("人口肺でコロナはイチコロよ！");
        }
    }
}
