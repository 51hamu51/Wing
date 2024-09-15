
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

    }
    void Update()
    {
        Env Env;
        GameObject obj = GameObject.Find("Environment");
        Env = obj.GetComponent<Env>();
        if (this.transform.position.y < Env.PinDestHeight)
        {
            Env.PinStandNumber[PinNum] = false;
        }
    }
}
