
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SweeperManager : UdonSharpBehaviour
{
    public Env Env;
    void Start()
    {
        Instantiate(Env.PINS, new Vector3(0, 0, 0), Quaternion.identity, Env.Sweeper);
    }
}
