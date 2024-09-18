
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SweeperClearSwitch : UdonSharpBehaviour
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
        if (Env.BowlingOrder == 21)
        {
            Debug.Log("finish");
        }
        else if (Env.BowlingOrder == 19 && Env.BowlingScoreAll[18] != 10)
        {
            for (int i = 1; i < 11; i++)
            {
                if (Env.PinStandNumber[i] == false && Env.PinDestroyNumber[i] == false)
                {
                    Env.BowlingScore++;
                    GameObject obj = GameObject.Find("BowlingPin" + i);
                    Destroy(obj);
                    Env.PinDestroyNumber[i] = true;
                }
            }
            Env.BowlingScoreAll[Env.BowlingOrder] = Env.BowlingScore;
            Env.BowlingOrder += 2;
            Env.BowlingScore = 0;
            Env.BowlingResetDestroy = true;
        }
        else if (Env.BowlingOrder == 19)
        {
            for (int i = 1; i < 11; i++)
            {
                if (Env.PinStandNumber[i] == false && Env.PinDestroyNumber[i] == false)
                {
                    Env.BowlingScore++;
                    GameObject obj = GameObject.Find("BowlingPin" + i);
                    Destroy(obj);
                    Env.PinDestroyNumber[i] = true;
                }
            }
            Env.BowlingScoreAll[Env.BowlingOrder] = Env.BowlingScore;
            Env.BowlingOrder++;
            Env.BowlingScore = 0;

        }
        else
        {
            for (int i = 1; i < 11; i++)
            {
                if (Env.PinStandNumber[i] == false && Env.PinDestroyNumber[i] == false)
                {
                    Env.BowlingScore++;
                    GameObject obj = GameObject.Find("BowlingPin" + i);
                    Destroy(obj);
                    Env.PinDestroyNumber[i] = true;
                }
            }

            Env.BowlingScoreAll[Env.BowlingOrder] = Env.BowlingScore;
            Env.BowlingOrder++;
            Env.BowlingScore = 0;
            if (Env.BowlingOrder % 2 == 0)
            {


                Env.BowlingResetDestroy = true;

            }
        }
    }
}
