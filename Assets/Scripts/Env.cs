
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Env : UdonSharpBehaviour
{

    public string BBall = "FieldBall";
    public string SBall = "FieldBall";
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

}
