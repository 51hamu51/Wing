
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class cube_udon : UdonSharpBehaviour
{
    bool cubeIsGold = true;
    public Material[] cubeMaterials = new Material[2];
    public override void InputDrop(bool value, UdonInputEventArgs args)
    {
        if(value){
            base.InputDrop(value, args);
            if (cubeIsGold)
            {
                GetComponent<MeshRenderer>().material = cubeMaterials[1];
                cubeIsGold = false;
            }
            else
            {
                GetComponent<MeshRenderer>().material = cubeMaterials[0];
                cubeIsGold = true;
            }
        }
    }

}
