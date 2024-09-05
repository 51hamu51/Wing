
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.SceneManagement;

public class PlayerTower : UdonSharpBehaviour
{

    public Env Env;
    private string objName;
    void Update()
    {

        this.transform.position = Networking.LocalPlayer.GetPosition();
    }
    public void OnTriggerEnter(Collider other)
    {

        objName = other.gameObject.name;
        if (objName == Env.FieldBall)
        {
            Debug.Log(objName);
        }

        /* if (this.gameObject.Tag == "Ball")
        {
            Destroy(other);
        } */

    }
}
