
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Switch_Mirror : UdonSharpBehaviour
{

    public GameObject targetMirror;
    public GameObject targetMirrorSwitchOn;
    public GameObject targetMirrorSwitchOff;
    public GameObject oppositMirror;
    public GameObject oppositMirrorSwitchOn;
    public GameObject oppositMirrorSwitchOff;

    
    public override void Interact()
    {
        targetMirror.SetActive(!targetMirror.activeSelf);
        targetMirrorSwitchOn.SetActive(!targetMirrorSwitchOn.activeSelf);
        targetMirrorSwitchOff.SetActive(!targetMirrorSwitchOff.activeSelf);
        
        oppositMirror.SetActive(false);
        oppositMirrorSwitchOn.SetActive(false);
        oppositMirrorSwitchOff.SetActive(true);
    }
}
