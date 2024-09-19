
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AnkSelect : UdonSharpBehaviour
{
    public Env Env;

    void Start()
    {

        Env.AnkSelectText.text = string.Format("{0} / {1} / {2}", Env.AnkPre[Env.Ank[0]], Env.AnkGene[Env.Ank[1]], Env.AnkFeed[Env.Ank[2]]);

    }
    void Update()
    {
        Env.AnkSelectText.text = string.Format("{0} / {1} / {2}", Env.AnkPre[Env.Ank[0]], Env.AnkGene[Env.Ank[1]], Env.AnkFeed[Env.Ank[2]]);
    }
}
