
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MemoryGameCardsDestroy : UdonSharpBehaviour
{

    void Start()
    {

    }
    void Update()
    {
        Env Env;
        GameObject obj = GameObject.Find("Environment");
        Env = obj.GetComponent<Env>();
        if (Env.MemoryNew == true)
        {
            Destroy(this.gameObject);
        }
    }
}
