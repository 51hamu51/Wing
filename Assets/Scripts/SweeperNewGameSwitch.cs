
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SweeperNewGameSwitch : UdonSharpBehaviour
{
    public Env Env;
    [SerializeField]
    private GameObject SwitchOn;
    [SerializeField]
    private GameObject SwitchOff;
    void Start()
    {

    }
    public override void Interact()
    {

    }
}
