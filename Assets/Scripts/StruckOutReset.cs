
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class StruckOutReset : UdonSharpBehaviour
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
            if ((Env.ResetDistance * -1) < differenceX && differenceX < Env.ResetDistance && (Env.ResetDistance * -1) < differenceZ && differenceZ < Env.ResetDistance)
            {



                base.InputDrop(value, args);
                for (int i = 1; i < 10; i++)
                {
                    Env.TatgetOnNumber[i] = true;
                }
            }
        }
    }
}
