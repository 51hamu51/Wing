
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class BowlingPin : UdonSharpBehaviour
{

    [SerializeField]
    private int PinNum;
    void Start()
    {
        Env Env;
        GameObject obj = GameObject.Find("Environment");
        Env = obj.GetComponent<Env>();

        Env.PinStandNumber[PinNum] = true;

    }
    void Update()
    {
        Env Env;
        GameObject obj = GameObject.Find("Environment");
        Env = obj.GetComponent<Env>();
        GameObject child = transform.GetChild(0).gameObject;
        if (child.transform.position.y < Env.PinDestHeight)
        {
            Env.PinStandNumber[PinNum] = false;
        }
    }
}
