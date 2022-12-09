using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float_DivisionBy10_Console : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float a = 0.1f;
        float b = 0.2f;

        float c = 1f;
        float d = 2f;

        float e = 0.3f;

        float x;

        Debug.Log("a = " + a.ToString("0.000000"));
        Debug.Log("b = " + b.ToString("0.000000"));
        Debug.Log("c = " + c.ToString("0.000000"));
        Debug.Log("d = " + d.ToString("0.000000"));
        Debug.Log("e = " + e.ToString("0.000000"));

        Debug.Log("0.1 + 0.2 = " + (a + b).ToString("0.000000"));
        Debug.Log("(a + b) is a : " + (a + b).GetType());
        Debug.Log("0.3 == (0.1 + 0.2) : " + (0.3f == (a + b)).ToString());
        Debug.Log("0.3 > (0.1 + 0.2) : " + (0.3f > (a + b)).ToString());
        Debug.Log("0.3 < (0.1 + 0.2) : " + (0.3f < (a + b)).ToString());

        var y = a + b;

        Debug.Log("y is a : " + y.GetType());
        Debug.Log("y = " + y.ToString("0.000000"));
        Debug.Log("0.3 == y : " + (0.3f == y).ToString());
        Debug.Log("0.3 > y : " + (0.3f > y).ToString());
        Debug.Log("0.3 < y : " + (0.3f < y).ToString());

        x = a + b;
        Debug.Log("x is a : " + x.GetType());
        Debug.Log("x = 0.1 + 0.2 = " + (x).ToString("0.000000"));
        Debug.Log("0.3 == x) : " + (0.3f == x).ToString());
        Debug.Log("0.3 > x : " + (0.3f > x).ToString());
        Debug.Log("0.3 < x : " + (0.3f < x).ToString());

        Debug.Log("e = 0.3f = " + e.ToString("0.000000"));
        Debug.Log("e == x) : " + (e == x).ToString());
        Debug.Log("e > x : " + (e > x).ToString());
        Debug.Log("e < x : " + (e < x).ToString());

        Debug.Log("1 + 2 = " + (c+d).ToString("0.000000"));
        Debug.Log("3 == (1 + 2) : " + (3f == (c + d)).ToString());
        Debug.Log("3 > (1 + 2) : " + (3f > (c + d)).ToString());
        Debug.Log("3 < (1 + 2) : " + (3f < (c + d)).ToString());

        Debug.Log("(1 + 2)/10 = "+ ((c + d) / 10f).ToString("0.000000"));
        Debug.Log("0.3 == (1+2)/10 : " + (0.3f == ((c+d)/10)).ToString());
        Debug.Log("0.3 > (1+2)/10 : " + (0.3f > ((c+d)/10)).ToString());
        Debug.Log("0.3 < (1+2)/10 : " + (0.3f < ((c+d)/10)).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
