
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StruckBallGenerate : UdonSharpBehaviour
{
    public Env Env;
    void Start()
    {
        Vector3 BallPosition = Env.StruckBallPoint.transform.position;
        Instantiate(Env.StruckBall, BallPosition, Quaternion.identity, Env.StruckOut);
        Env.StruckBallAlive = true;
    }
    void Update()
    {
        if (Env.StruckBallAlive == false)
        {
            Vector3 BallPosition = Env.StruckBallPoint.transform.position;
            Instantiate(Env.StruckBall, BallPosition, Quaternion.identity, Env.StruckOut);
            Env.StruckBallAlive = true;
        }
    }
}
