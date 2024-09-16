
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
    void Update()
    {
        if (Env.MemoryNew == true)
        {

            Env.MemoryCardFront = -1;
            Env.MemoryFirst = true;
            Env.MemoryPoint = 0;
            Vector3 CardPosition = Env.CardPoint.transform.position;
            Instantiate(Env.MemoryGameCards, CardPosition, Quaternion.identity, Env.MemoryGame);

            for (int i = 0; i < 3; i++)
            {
                Env.MemoryCardAlive[i] = true;
            }

            Env.MemoryNew = false;
        }
    }
}
