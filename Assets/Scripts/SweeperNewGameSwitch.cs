
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
        // SwitchOn.SetActive(false);
        //SwitchOff.SetActive(true);
        Env.BowlingOrder = 0;
        Env.BowlingScore = 0;
        Env.BowlingResetDestroy = true;
        for (int i = 0; i < 22; i++)
        {
            Env.BowlingScoreAll[i] = 0;
        }
    }
}
