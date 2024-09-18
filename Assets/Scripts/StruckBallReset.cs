
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StruckBallReset : UdonSharpBehaviour
{

    private string objName;
    void Start()
    {

    }
    public void OnCollisionEnter(Collision other)
    {
        Env Env;
        GameObject obj = GameObject.Find("Environment");
        Env = obj.GetComponent<Env>();

        objName = other.gameObject.name;
        if (objName == Env.FloorName)
        {
            Env.StruckBallAlive = false;
            Destroy(this.gameObject);


        }
    }
}
