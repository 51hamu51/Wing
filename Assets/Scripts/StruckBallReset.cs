
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
    void Update()
    {
        Env Env;
        GameObject obj = GameObject.Find("Environment");
        Env = obj.GetComponent<Env>();
        if (this.transform.position.y < Env.StruckBallDestHeight)
        {
            Env.StruckBallAlive = false;
            Destroy(this.gameObject);
        }
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
