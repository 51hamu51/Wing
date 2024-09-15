
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class SweeperScore : UdonSharpBehaviour
{
    public Env Env;
    private int x;

    void Start()
    {

        Env.SweeperScoreText.text = string.Format("{0}", Env.BowlingScore);

    }
    void Update()
    {
        x = 0;
        for (int i = 0; i < 21; i++)
        {
            x += Env.BowlingScoreAll[i];
        }
        Env.BowlingScoreAll[21] = x;
        Env.SweeperScoreText.text = string.Format("{0} {1} / {2} {3} / {4} {5} / {6} {7} / {8} {9} / {10} {11} / {12} {13} / {14} {15} / {16} {17} / {18} {19} {20} \n  sum: {21}     order:{22}", Env.BowlingScoreAll[0], Env.BowlingScoreAll[1], Env.BowlingScoreAll[2], Env.BowlingScoreAll[3], Env.BowlingScoreAll[4], Env.BowlingScoreAll[5], Env.BowlingScoreAll[6], Env.BowlingScoreAll[7], Env.BowlingScoreAll[8], Env.BowlingScoreAll[9], Env.BowlingScoreAll[10], Env.BowlingScoreAll[11], Env.BowlingScoreAll[12], Env.BowlingScoreAll[13], Env.BowlingScoreAll[14], Env.BowlingScoreAll[15], Env.BowlingScoreAll[16], Env.BowlingScoreAll[17], Env.BowlingScoreAll[18], Env.BowlingScoreAll[19], Env.BowlingScoreAll[20], Env.BowlingScoreAll[21], Env.BowlingOrder + 1);
    }
}
