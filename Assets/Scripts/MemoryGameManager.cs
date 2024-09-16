
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MemoryGameManager : UdonSharpBehaviour
{
    public Env Env;
    void Start()
    {

        Vector3 CardPosition = Env.CardPoint.transform.position;
        Instantiate(Env.MemoryGameCards, CardPosition, Quaternion.identity, Env.MemoryGame);

    }
}
