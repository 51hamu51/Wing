
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MemoryNewGameSwitch : UdonSharpBehaviour
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

        // SwitchOn.SetActive(false);
        //SwitchOff.SetActive(true);
        Env.MemoryNew = true;
    }
}
