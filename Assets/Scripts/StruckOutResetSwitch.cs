
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StruckOutResetSwitch : UdonSharpBehaviour
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
        for (int i = 1; i < 10; i++)
        {
            Env.TatgetOnNumber[i] = true;
        }
    }
}
