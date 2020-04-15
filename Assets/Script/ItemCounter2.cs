using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCounter2 : MonoBehaviour
{
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
            Destroy(this.gameObject);
            //Debug.Log("人口肺でコロナはイチコロよ！");
        }
    }
}
