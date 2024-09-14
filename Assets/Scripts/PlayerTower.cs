
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
        this.transform.rotation = Networking.LocalPlayer.GetRotation();
    }
    public void OnTriggerEnter(Collider other)
    {

        objName = other.gameObject.name;
        if (objName == Env.BBall || objName == Env.FBall)
        {
            Debug.Log(objName);
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            /*  rigidbody.AddForce(1000, 100, 0); */
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.AddForce(transform.forward * Env.KickForce, ForceMode.Impulse);
            rigidbody.AddForce(transform.up * Env.KickForceUp, ForceMode.Impulse);
            rigidbody.AddTorque(transform.right * Env.KickForceRotate, ForceMode.Impulse);


        }

        /* if (this.gameObject.Tag == "Ball")
        {
            Destroy(other);
        } */

    }
}
