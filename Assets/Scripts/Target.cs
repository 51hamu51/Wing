
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Target : UdonSharpBehaviour
{
    [SerializeField]
    private int TargetNum;
    public Env Env;
    private string objName;
    void Start()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        objName = collision.gameObject.name;
        if (objName == Env.SBall)
        {

            Env.TatgetOnNumber[TargetNum] = false;

        }
    }

    public void Update()
    {
        if (Env.TatgetOnNumber[TargetNum] == true)
        {
            this.gameObject.GetComponent<Renderer>().material = Env.TatgetOnMaterial;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = Env.TatgetOffMaterial;
        }
    }

}
