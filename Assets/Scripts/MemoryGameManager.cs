
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MemoryGameManager : UdonSharpBehaviour
{
    public Env Env;
    private int temp;
    void Start()
    {

        Vector3 CardPosition = Env.CardPoint.transform.position;
        Instantiate(Env.MemoryGameCards, CardPosition, Quaternion.identity, Env.MemoryGame);

        for (int i = 0; i < Env.MemoryCardHowMany; i++)
        {
            Env.MemoryPictureNum[i] = i / 2;
        }
        int rnd1 = Random.Range(2, 6);
        for (int j = 0; j < rnd1; j++)
        {
            int rnd2 = Random.Range(0, Env.MemoryCardHowMany);
            int rnd3 = Random.Range(0, Env.MemoryCardHowMany);
            temp = Env.MemoryPictureNum[rnd2];
            Env.MemoryPictureNum[rnd2] = Env.MemoryPictureNum[rnd3];
            Env.MemoryPictureNum[rnd3] = temp;
        }



    }
    void Update()
    {
        if (Env.MemoryNew == true)
        {
            int rnd1 = Random.Range(2, 6);
            for (int j = 0; j < rnd1; j++)
            {
                int rnd2 = Random.Range(0, Env.MemoryCardHowMany);
                int rnd3 = Random.Range(0, Env.MemoryCardHowMany);
                temp = Env.MemoryPictureNum[rnd2];
                Env.MemoryPictureNum[rnd2] = Env.MemoryPictureNum[rnd3];
                Env.MemoryPictureNum[rnd3] = temp;
            }





            Env.MemoryCardFront = -1;
            Env.MemoryFirst = true;
            Env.MemoryPoint = 0;
            Vector3 CardPosition = Env.CardPoint.transform.position;
            Instantiate(Env.MemoryGameCards, CardPosition, Quaternion.identity, Env.MemoryGame);

            for (int i = 0; i < Env.MemoryCardHowMany / 2; i++)
            {
                Env.MemoryCardAlive[i] = true;
            }

            Env.MemoryNew = false;
        }
    }
}
