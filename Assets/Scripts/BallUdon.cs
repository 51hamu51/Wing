
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;


public class BallUdon : UdonSharpBehaviour
{

    public Env Env;
    void Start()
    {

    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {

        /*  VRCPlayerApi player = collision.gameObject.GetComponent<VRCPlayerApi>(); */
        if (player != null && player == Networking.LocalPlayer)
        {
            Debug.Log("hit");
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(1, 0, 0);

        }

    }

}
