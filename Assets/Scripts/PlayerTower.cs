
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerTower : UdonSharpBehaviour
{


    void Update()
    {

        this.transform.position = Networking.LocalPlayer.GetPosition();
    }
    public void OnTriggerEnter(Collider other)
    {

        /* if (this.gameObject.Tag == "Ball")
        {
            Destroy(other);
        } */

    }
}
