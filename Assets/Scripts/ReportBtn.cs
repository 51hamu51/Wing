
using UdonSharp;
using UnityEngine;
using VRC.SDK3.StringLoading;
using VRC.SDKBase;
using VRC.Udon;

public class ReportBtn : UdonSharpBehaviour
{
    public Env Env;
    private VRCUrl testUrl = new VRCUrl("http://localhost/%E3%83%86%E3%82%B9%E3%83%88%E5%9C%B0%E6%96%B9/%E3%83%86%E3%82%B9%E3%83%88%E4%BB%A3/%E3%83%86%E3%82%B9%E3%83%88");
    void Start()
    {

    }
    public override void Interact()
    {
        VRCStringDownloader.LoadUrl(testUrl, this.GetComponent<UdonBehaviour>());
    }
}
