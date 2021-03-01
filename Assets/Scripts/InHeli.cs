using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InHeli : MonoBehaviour
{
    public static int soldierInHeli;
    Text Soldiercount;
    // Start is called before the first frame update
    void Start()
    {
        Soldiercount = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        
        Soldiercount.text = "Soldier's in helicopter: " + soldierInHeli;
    }
}
