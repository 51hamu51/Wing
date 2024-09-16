
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Quiz_Item : UdonSharpBehaviour
{
    [Tooltip("選択肢をシャッフルするか")]
    public bool isShuffle = true;
    [TextArea]
    public string title;
    [Header("最大4つまで指定できます")]
    [TextArea]
    public string[] select;
    public int[] answer_index;
    [TextArea]
    public string comment;
    public float score;
    public void gen(){
    }
}
