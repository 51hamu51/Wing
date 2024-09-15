
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SweeperManager : UdonSharpBehaviour
{
    public Env Env;
    void Start()
    {
        Env.BowlingOrder = 0;
        Env.PinStand = true;
        Vector3 PinPosition = Env.PinPoint.transform.position;
        Instantiate(Env.PINS, PinPosition, Quaternion.identity, Env.Sweeper);
        for (int i = 1; i < 11; i++)
        {
            Env.PinDestroyNumber[i] = false;
        }
    }
    void Update()
    {
        if (Env.PinStand == false)
        {
            if (Env.BowlingOrder % 2 == 0)
            {
                Env.BowlingScoreAll[Env.BowlingOrder] = 10;
                Env.BowlingOrder += 2;
            }
            else
            {
                Env.BowlingScoreAll[Env.BowlingOrder] = 10 - Env.BowlingScoreAll[Env.BowlingOrder - 1];
                Env.BowlingOrder++;
            }
            Env.PinStand = true;
            Vector3 PinPosition = Env.PinPoint.transform.position;
            Instantiate(Env.PINS, PinPosition, Quaternion.identity, Env.Sweeper);
            for (int i = 1; i < 11; i++)
            {
                Env.PinDestroyNumber[i] = false;
            }

        }
        if (Env.BowlingResetDestroy == true)
        {
            Vector3 PinPosition = Env.PinPoint.transform.position;
            Instantiate(Env.PINS, PinPosition, Quaternion.identity, Env.Sweeper);
            Env.BowlingResetDestroy = false;
            for (int i = 1; i < 11; i++)
            {
                Env.PinDestroyNumber[i] = false;
            }
        }
    }

}
