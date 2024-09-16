
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class Quiz_Btn : UdonSharpBehaviour
{

    public string text;
    public int num;
    public UdonBehaviour motherboard;

    void Start()
    {
    }

    public void trigger()
    {
        int[] ans = (int[])motherboard.GetProgramVariable("current_select");
        for (int i = 0; i < ans.Length; i++)
        {
            if (ans[i] == num)
            {
                motherboard.SendCustomEvent("correct");
                return;
            }
        }
        motherboard.SendCustomEvent("incorrect");

    }
}
