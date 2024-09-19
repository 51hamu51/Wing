
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AnkBtn : UdonSharpBehaviour
{
    public Env Env;
    [SerializeField]
    private int sort;//0:地域, 1:世代, 2:感想
    [SerializeField]
    private int num;
    void Start()
    {

    }

    public override void Interact()
    {
        Env.Ank[sort] = num;
        Debug.Log($"{Env.Ank[0]}/{Env.Ank[1]}/{Env.Ank[2]}");
    }
}