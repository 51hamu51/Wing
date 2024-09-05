
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;


public class BallUdon : UdonSharpBehaviour
{

    public Env Env;
    void Start()
    {
        Debug.Log("co");
        Hukkatu();
    }
    void Hukkatu()
    {
        Debug.Log("lli");
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {

            collider.enabled = true;

        }
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {


        /* if (player != null && player == Networking.LocalPlayer)
        {
            Debug.Log("hit");
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(1, 0, 0);

        } */

    }

}
