
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Env : UdonSharpBehaviour
{

    public string BBall = "BowlingBall";
    public string SBall = "FieldBall";
    public string FBall = "FieldBall";
    public float KickForce = 9.0f;
    public float KickForceUp = 5.0f;
    public float KickForceRotate = 3.0f;
    public Material TatgetOnMaterial;
    public Material TatgetOffMaterial;
    public bool[] TatgetOnNumber = new bool[10];
    public float ResetDistance = 3.0f;
    public float KickerFieldDistance = 2.0f;
    public GameObject PINS;
    public Transform Sweeper;

    public GameObject PinPoint;
    public bool PinStand;
    public float PinDestHeight = 0.2f;
    public bool[] PinStandNumber = new bool[11];

}
