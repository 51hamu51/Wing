﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;


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
    public float SweeperClearDistance = 3.0f;
    public float MemoryGameCardDistance = 2.0f;
    public float KickerFieldDistance = 2.0f;
    public GameObject PINS;
    public Transform Sweeper;

    public GameObject PinPoint;
    public bool PinStand;
    public float PinDestHeight = 0.184f;
    public bool[] PinStandNumber = new bool[11];
    public bool[] PinDestroyNumber = new bool[11];
    public TextMeshProUGUI SweeperScoreText;
    public int BowlingScore;
    public int[] BowlingScoreAll = new int[22];
    public int BowlingOrder;
    public bool BowlingResetDestroy;
    public bool[] MemoryCardAlive = new bool[2];
    public int MemoryCardFront;
    public bool MemoryFirst;
    public int MemoryPoint;
    public Material[] MemoryMaterials = new Material[2];
    public Material MemoryDefaultMaterial;
    public GameObject MemoryGameCards;
    public GameObject CardPoint;
    public Transform MemoryGame;

}
