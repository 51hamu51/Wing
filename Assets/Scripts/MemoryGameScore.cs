
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MemoryGameScore : UdonSharpBehaviour
{
    public Env Env;
    void Start()
    {
        Env.MemoryScoreText.text = string.Format("{0}", Env.MemoryPoint);
    }
    void Update()
    {

        Env.MemoryScoreText.text = string.Format("{0}", Env.MemoryPoint);
    }
}
