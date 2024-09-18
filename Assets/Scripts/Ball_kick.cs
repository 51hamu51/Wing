
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class Ball_kick : UdonSharpBehaviour
{

    private bool SelectY = false;
    private bool SelectX = false;
    private bool Reseted = true;
    private int RotateDelta = 1;
    void Start()
    {

    }

    public override void Interact()
    {
        if (Reseted)
        {
            Reseted = false;
            SelectY = true;
            RotateDelta = 1;
        }
        else if (SelectY)
        {
            SelectY = false;
            SelectX = true;
            RotateDelta = -1;
        }
        else if (SelectX)
        {
            SelectX = false;
            Reseted = true;
        }
    }

    void Update()
    {
        GameObject child = gameObject.transform.GetChild(0).gameObject;
        // childのY軸を90~-90の範囲を往復させる
        if (SelectY)
        {
            if (child.transform.localEulerAngles.y < 270 && child.transform.localEulerAngles.y > 90)
            {
                RotateDelta *= -1;
            }
            child.transform.Rotate(0, RotateDelta, 0);
        }
        if (SelectX)
        {
            if (child.transform.localEulerAngles.x > 0 && child.transform.localEulerAngles.x < 271)
            {
                RotateDelta *= -1;
            }
            Debug.Log(child.transform.localEulerAngles.x);
            child.transform.Rotate(RotateDelta, 0, 0);
        }
    }
}
