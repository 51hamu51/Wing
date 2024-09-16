
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;
public class MemoryGameCard : UdonSharpBehaviour
{
    public Env Env;
    [SerializeField]
    private int MemoryNum;
    void Start()
    {

    }
    void Update()
    {
        if (Env.MemoryCardAlive[MemoryNum] == false)
        {
            Destroy(this.gameObject);
        }
        if (Env.MemoryFirst == true)
        {

            GetComponent<Renderer>().material.color = Env.MemoryDefaultMaterial.color;

        }

    }
    public override void InputDrop(bool value, UdonInputEventArgs args)
    {
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
                    Env.MemoryCardFront = MemoryNum;
                    GetComponent<Renderer>().material.color = Env.MemoryMaterials[MemoryNum].color;
                    Env.MemoryFirst = false;
                    Debug.Log("1");
                }
                else if (Env.MemoryCardFront == MemoryNum)
                {
                    Debug.Log("2");
                    Env.MemoryFirst = true;
                    Env.MemoryCardFront = -1;
                    GetComponent<Renderer>().material.color = Env.MemoryMaterials[MemoryNum].color;
                    Env.MemoryPoint++;


                    Env.MemoryCardAlive[MemoryNum] = false;

                }
                else
                {
                    Debug.Log("3");

                    GetComponent<Renderer>().material.color = Env.MemoryMaterials[MemoryNum].color;


                    Env.MemoryFirst = true;
                    Env.MemoryCardFront = -1;

                }

            }
        }
    }
}
