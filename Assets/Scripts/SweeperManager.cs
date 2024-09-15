
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SweeperManager : UdonSharpBehaviour
{
    public Env Env;
    void Start()
    {
        /*    Vector3 PinPosition = Env.PinPoint.transform.position;
           Instantiate(Env.PINS, PinPosition, Quaternion.identity, Env.Sweeper); */
    }
    void Update()
    {
        if (Env.PinStand == false)
        {
            Env.PinStand = true;
            Vector3 PinPosition = Env.PinPoint.transform.position;
            Instantiate(Env.PINS, PinPosition, Quaternion.identity, Env.Sweeper);
        }
    }
}
