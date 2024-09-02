
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class BallUdon : UdonSharpBehaviour
{
    void Start()
    {

    }

    public override void OnPlayerCollisionEnter(VRCPlayerApi player)
    {

        /*  VRCPlayerApi player = collision.gameObject.GetComponent<VRCPlayerApi>(); */
        if (player != null && player == Networking.LocalPlayer)
        {
            Debug.Log("hit");

        }

    }

}
