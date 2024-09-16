
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;
public class MemoryGameCard : UdonSharpBehaviour
{

    [SerializeField]
    private int MemoryNum;
    private bool BeforeCard;
    private bool BeforeCardFirst;
    void Start()
    {
        BeforeCard = false;
        BeforeCardFirst = false;
    }
    void Update()
    {
        Env Env;
        GameObject obj = GameObject.Find("Environment");
        Env = obj.GetComponent<Env>();

        if (Env.MemoryCardAlive[Env.MemoryPictureNum[MemoryNum]] == false)
        {
            Destroy(this.gameObject);
        }

        if (Env.MemoryFirst == false && BeforeCard == false)
        {

            GetComponent<Renderer>().material.color = Env.MemoryDefaultMaterial.color;

        }
        if (Env.MemoryFirst == false && BeforeCardFirst == false)
        {
            BeforeCard = false;
        }
        if (Env.MemoryFirst == true)
        {
            BeforeCardFirst = false;
        }


    }
    public override void InputDrop(bool value, UdonInputEventArgs args)
    {
        Env Env;
        GameObject obj = GameObject.Find("Environment");
        Env = obj.GetComponent<Env>();
        if (value)
        {
            var playerPosition = Networking.LocalPlayer.GetPosition();
            var differenceX = playerPosition.x - this.transform.position.x;
            var differenceZ = playerPosition.z - this.transform.position.z;
            if ((Env.MemoryGameCardDistance * -1) < differenceX && differenceX < Env.MemoryGameCardDistance && (Env.MemoryGameCardDistance * -1) < differenceZ && differenceZ < Env.MemoryGameCardDistance)
            {



                base.InputDrop(value, args);
                if (Env.MemoryFirst == true)
                {
                    BeforeCard = true;
                    BeforeCardFirst = true;

                    Env.MemoryCardFront = Env.MemoryPictureNum[MemoryNum];
                    GetComponent<Renderer>().material.color = Env.MemoryMaterials[Env.MemoryPictureNum[MemoryNum]].color;
                    Env.MemoryFirst = false;
                    Debug.Log("1");
                }
                else if (Env.MemoryCardFront == Env.MemoryPictureNum[MemoryNum])
                {
                    Debug.Log("2");
                    BeforeCard = true;
                    Env.MemoryFirst = true;
                    Env.MemoryCardFront = -1;
                    GetComponent<Renderer>().material.color = Env.MemoryMaterials[Env.MemoryPictureNum[MemoryNum]].color;
                    Env.MemoryPoint++;


                    Env.MemoryCardAlive[Env.MemoryPictureNum[MemoryNum]] = false;

                }
                else
                {
                    Debug.Log("3");
                    BeforeCard = true;
                    GetComponent<Renderer>().material.color = Env.MemoryMaterials[Env.MemoryPictureNum[MemoryNum]].color;


                    Env.MemoryFirst = true;
                    Env.MemoryCardFront = -1;

                }

            }
        }
    }
}
