using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbiganCountDirector : MonoBehaviour
{

    public int AbiCount;


    // Start is called before the first frame update
    private int scoreCount;
    public Text abimed;

    public void ColAbigan()
    {
       AbiCount+= 1;


    }

    // Update is called once per frame
    void Update()
    {
        abimed.GetComponent<Text>().text = "服用" + AbiCount + "/1".ToString();

    }
}
