
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class SweeperClear : UdonSharpBehaviour
{
    public Env Env;
    void Start()
    {

    }
    public override void InputDrop(bool value, UdonInputEventArgs args)
    {
        if (value)
        {
            var playerPosition = Networking.LocalPlayer.GetPosition();
            var differenceX = playerPosition.x - this.transform.position.x;
            var differenceZ = playerPosition.z - this.transform.position.z;
            if ((Env.SweeperClearDistance * -1) < differenceX && differenceX < Env.SweeperClearDistance && (Env.SweeperClearDistance * -1) < differenceZ && differenceZ < Env.SweeperClearDistance)
            {



                base.InputDrop(value, args);
                for (int i = 1; i < 11; i++)
                {
                    if (Env.PinStandNumber[i] == false)
                    {

                        GameObject obj = GameObject.Find("BowlingPin" + i);
                        Destroy(obj);
                    }
                }
            }
        }
    }
}
