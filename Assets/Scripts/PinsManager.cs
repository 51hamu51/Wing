﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PinsManager : UdonSharpBehaviour
{



    public GameObject Pins;

    void Start()
    {
        Env Env;
        GameObject obj = GameObject.Find("Environment");
        Env = obj.GetComponent<Env>();
        Env.PinStand = true;
        for (int j = 1; j < 11; j++)
        {
            Env.PinStandNumber[j] = true;


        }

    }
    void Update()
    {
        int x = 0;
        Env Env;
        GameObject obj = GameObject.Find("Environment");
        Env = obj.GetComponent<Env>();
        for (int i = 1; i < 11; i++)
        {
            if (Env.PinStandNumber[i] == false)
            {
                x++;

            }


        }
        if (x == 10)
        {
            Env.PinStand = false;
            Destroy(Pins);
        }

    }

}
