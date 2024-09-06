
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;
public class StruckOutKicker : UdonSharpBehaviour
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
            if ((Env.KickerFieldDistance * -1) < differenceX && differenceX < Env.KickerFieldDistance && (Env.KickerFieldDistance * -1) < differenceZ && differenceZ < Env.KickerFieldDistance)
            {



                base.InputDrop(value, args);
                /* ここにやることを書く */
            }
        }
    }
}
