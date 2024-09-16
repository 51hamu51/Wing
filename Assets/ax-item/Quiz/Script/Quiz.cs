
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
#if UDON_CHIPS
using UCS;
#endif
[System.Serializable]
public class Quiz : UdonSharpBehaviour
{
#if UDON_CHIPS
    private UdonChips udonChips = null;
#endif
    [Header("Tooltipに変数の意味が書いてあります")]
    [Tooltip("合格とみなす正答数")]
    public int requie_answer = 4;

    [Tooltip("許容する誤答数")]
    public int ignore_incorrect = 2;
    [Tooltip("解答後に解説を表示するか")]
    public bool isCommentary = true;
    [Tooltip("終了後に結果画面を表示するか")]
    public bool isResult = true;
    [Tooltip("クイズ終了後クイズウィンドウを非表示にするか")]
    public bool isQuizEndToClose = true;
    [Tooltip("クイズ終了後テキストを出すか")]
    public bool isQuizEndToText = true;
    [Tooltip("スコアの表示")]
    public bool isScoreView = true;
    [Tooltip("結果画面に表示するテキスト")]
    public string success_text = "合格", failed_text = "不合格";
    [Header("スコアをそのままUdonChipsとして支払う")]
    public bool isScore2Money = false;
    [Header("合格時のみ支払う")]
    public bool isAllOKOnly2Pay = false;
    [Header("指定問題数を解かせるモード")]
    [Tooltip("※有効にするとrequie_answerが合格点になります")]
    public bool maxMode = false;
    [Tooltip("何問解かせるか")]
    public int maxQuestion = 10;

    [Header("正解時")]
    public AudioSource correct_audio;
    [Header("合格時")]
    public AudioSource allOK_audio;
    public GameObject[] allOK_enableObject;
    public GameObject[] allOK_disableObject;
    public UdonBehaviour allOK_Udon;
    public string allOK_Udon_MethodName;
    public float allOK_TakeMoney;
    [Header("不正解時")]
    public AudioSource incorrect_audio;

    [Header("不合格時")]
    public AudioSource failed_audio;
    public GameObject[] incorrect_enableObject;
    public GameObject[] incorrect_disableObject;
    public UdonBehaviour incorrect_Udon;
    public string incorrect_Udon_MethodName;
    public float incorrect_TakeMoney;
    [Header("---------------")]
    public GameObject[] btn_group;
    public GameObject items_group, canvas;
    public GameObject q, a, r, f, s, correct_mark, incorrect_mark, go_score;
    public TextMeshProUGUI TM_title, TM_answer, TM_comment, TM_result_title, TM_result_details, TM_Score, TM_udonchips;
    public int current_correct = 0, current_incorrect_answer = 0;
    public float score = 0;
    public int[] current_select;
    public Quiz_Item current_quiz;
    private string already_question, format;

    public void OnEnable()
    {
        reset();
    }

    public void reset()
    {
#if UDON_CHIPS
        if (udonChips == null)
        {
            udonChips = (UdonChips)GameObject.Find("UdonChips").GetComponent<UdonChips>();
            if (string.IsNullOrEmpty(format))
            {
                format = udonChips.format;
            }
        }
#endif
        current_correct = 0;
        current_incorrect_answer = 0;
        score = 0;
        already_question = "";
        canvas.SetActive(true);
        q.SetActive(true);
        a.SetActive(false);
        if(r != null) r.SetActive(false);
        if(s != null) s.SetActive(false);
        if(f != null) f.SetActive(false);
        if (go_score != null)
        {
            if (isScoreView)
            {
                go_score.SetActive(true);
            }
            else
            {
                go_score.SetActive(false);
            }
        }
        if (items_group.transform.childCount != 0)
        {
            pickUpNewQuestion();
        }
        else
        {
            Debug.Log("問題がありません...");
        }
        foreach (GameObject obj in incorrect_enableObject)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in incorrect_disableObject)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in allOK_enableObject)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in allOK_disableObject)
        {
            obj.SetActive(true);
        }
    }

    void Update()
    {
        if (TM_Score != null) TM_Score.text = score + "";
    }

    public void pickUpNewQuestion()
    {
        q.SetActive(true);
        a.SetActive(false);
        GameObject[] items = new GameObject[items_group.transform.childCount];
        if (items.Length == 0)
        {
            Debug.Log("問題がありません...");
            return;
        }
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = items_group.transform.GetChild(i).gameObject;
        }
        int rnd = 0, cnt = 0;
        UdonBehaviour item;
        string[] ans_l;
        bool isFound = false;
        do
        {
            rnd = Random.Range(0, items.Length);
            isFound = false;
            foreach (string i in already_question.Split(','))
            {
                if (!i.Equals("") && int.Parse(i) == rnd)
                {
                    isFound = true;
                    break;
                }
            }
            current_quiz = (Quiz_Item)items[rnd].GetComponent<Quiz_Item>();
            item = (UdonBehaviour)items[rnd].GetComponent(typeof(UdonBehaviour));
            item.SendCustomEvent("gen");
            ans_l = (string[])item.GetProgramVariable("select");
            cnt++;
        } while (ans_l.Length > 4 && cnt <= items.Length || isFound);
        if (already_question.Equals(""))
        {
            already_question = rnd + "";
        }
        else
        {
            already_question += "," + rnd;
        }
        if (already_question.Split(',').Length >= items.Length) already_question = "";

        TM_title.text = (string)item.GetProgramVariable("title");
        current_select = (int[])item.GetProgramVariable("answer_index");
        bool isShuffle = (bool)item.GetProgramVariable("isShuffle");
        for (int i = 0; i < btn_group.Length; i++)
        {
            GameObject obj = btn_group[i];
            UdonBehaviour udon = (UdonBehaviour)obj.GetComponent(typeof(UdonBehaviour));
            TextMeshProUGUI tm = (TextMeshProUGUI)obj.transform.Find("Text").GetComponent(typeof(TextMeshProUGUI));
            if (i < ans_l.Length)
            {
                string temp = ans_l[i];
                udon.SetProgramVariable("text", temp);
                udon.SetProgramVariable("num", i);
                tm.text = temp;
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
            if (isShuffle)
            {
                obj.transform.SetSiblingIndex(Random.Range(0, btn_group.Length));
            }
            else
            {
                obj.transform.SetSiblingIndex(i);
            }
        }
        string str = "";
        foreach (int i in current_select)
        {
            str += ans_l[i] + ", ";
        }
        TM_answer.text = str.Substring(0, str.Length - 2);
        TM_comment.text = (string)item.GetProgramVariable("comment");
    }

    public void allOK_Money()
    {
#if UDON_CHIPS
        if (udonChips != null)
        {
            float money = 0;
            money += allOK_TakeMoney;
            if (isScore2Money)
            {
                money += score;
            }
            udonChips.money += money;
            if (money < 0)
            {
                TM_udonchips.text = "没収: " + string.Format(format, -money);
            }
            else
            {
                TM_udonchips.text = "獲得: " + string.Format(format, money);
            }
        }
#endif
    }

    public void incorrect_Money()
    {
#if UDON_CHIPS
        if (udonChips != null)
        {
            float money = 0;
            money += incorrect_TakeMoney;
            if (isScore2Money && !isAllOKOnly2Pay)
            {
                money += score;
            }
            udonChips.money += money;
            if (money < 0)
            {
                TM_udonchips.text = "没収: " + string.Format(format, -money);
            }
            else
            {
                TM_udonchips.text = "獲得: " + string.Format(format, money);
            }
        }
#endif
    }

    public void nextScreen()
    {
        if (maxMode)
        {
            if ((current_correct + current_incorrect_answer) >= maxQuestion)
            {
                if (isResult)
                {
                    resultScreen();
                }
                else
                {
                    if (current_correct >= requie_answer)
                    {
                        if (allOK_audio != null) allOK_audio.Play();
                        AllOKProcess();
                        allOK_Money();
                    }
                    else
                    {
                        if (failed_audio != null) failed_audio.Play();
                        IncorrectProcess();
                        incorrect_Money();
                    }
                }
            }
            else
            {
                pickUpNewQuestion();
            }
        }
        else
        {
            if (current_correct >= requie_answer)
            {
                if (isResult)
                {
                    resultScreen();
                }
                else
                {
                    if (allOK_audio != null) allOK_audio.Play();
                    AllOKProcess();
                    allOK_Money();
                }
                return;
            }
            if (current_incorrect_answer > ignore_incorrect)
            {
                if (isResult)
                {
                    resultScreen();
                }
                else
                {
                    if (failed_audio != null) failed_audio.Play();
                    IncorrectProcess();
                    incorrect_Money();
                }
                return;
            }
            pickUpNewQuestion();
        }
    }

    public void correct()
    {
        current_correct++;
        score += current_quiz.score;
        if (correct_audio != null) correct_audio.Play();
        if (isCommentary)
        {
            q.SetActive(false);
            a.SetActive(true);
            correct_mark.gameObject.SetActive(true);
            incorrect_mark.gameObject.SetActive(false);
        }
        else
        {
            nextScreen();
        }
    }

    public void incorrect()
    {
        if (incorrect_audio != null) incorrect_audio.Play();
        current_incorrect_answer++;
        if (isCommentary)
        {
            q.SetActive(false);
            a.SetActive(true);
            incorrect_mark.gameObject.SetActive(true);
            correct_mark.gameObject.SetActive(false);
        }
        else
        {
            nextScreen();
        }
    }

    public void resultScreen()
    {
        q.SetActive(false);
        a.SetActive(false);
        r.SetActive(true);
        if(TM_result_details != null) TM_result_details.text = (current_correct + current_incorrect_answer) + "問中 / " + current_correct + "問正解  " + current_incorrect_answer + "問不正解";
        if(TM_udonchips != null) TM_udonchips.text = "";
        if (maxMode)
        {
            if (current_correct >= requie_answer)
            {
                if (allOK_audio != null) allOK_audio.Play();
                if(TM_result_title != null) TM_result_title.text = success_text;
                allOK_Money();
            }
            else
            {
                if (failed_audio != null) failed_audio.Play();
                if(TM_result_title != null) TM_result_title.text = failed_text;
                incorrect_Money();
            }
            if(TM_result_details != null) TM_result_details.text += " (合格: " + requie_answer + "問)";
        }
        else
        {
            if (current_incorrect_answer >= ignore_incorrect)
            {
                if (failed_audio != null) failed_audio.Play();
                if(TM_result_title != null) TM_result_title.text = failed_text;
                incorrect_Money();
            }
            else
            {
                if (allOK_audio != null) allOK_audio.Play();
                if(TM_result_title != null) TM_result_title.text = success_text;
                allOK_Money();
            }
        }
    }

    public void resultClose()
    {
        if (maxMode)
        {
            if (current_correct >= requie_answer)
            {
                AllOKProcess();
            }
            else
            {
                IncorrectProcess();
            }
        }
        else
        {
            if (current_correct >= requie_answer)
            {
                AllOKProcess();
                return;
            }
            if (current_incorrect_answer >= ignore_incorrect)
            {
                IncorrectProcess();
                return;
            }
            pickUpNewQuestion();
        }
    }

    public void AllOKProcess()
    {
        foreach (GameObject obj in allOK_enableObject)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in allOK_disableObject)
        {
            obj.SetActive(false);
        }
        if (allOK_Udon != null && !allOK_Udon_MethodName.Equals(""))
        {
            allOK_Udon.SendCustomEvent(allOK_Udon_MethodName);
        }
        q.SetActive(false);
        a.SetActive(false);
        if(r != null) r.SetActive(false);
        if(isQuizEndToText){
            if(s != null) s.SetActive(true);
            if(f != null) f.SetActive(false);
        } else if (isQuizEndToClose)
        {
            canvas.SetActive(false);
        }
        else
        {
            reset();
        }

    }
    public void IncorrectProcess()
    {
        foreach (GameObject obj in incorrect_enableObject)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in incorrect_disableObject)
        {
            obj.SetActive(false);
        }
        if (incorrect_Udon != null && !incorrect_Udon_MethodName.Equals(""))
        {
            incorrect_Udon.SendCustomEvent(incorrect_Udon_MethodName);
        }
        q.SetActive(false);
        a.SetActive(false);
        if(r != null) r.SetActive(false);
        if(isQuizEndToText){
            if(f != null) f.SetActive(true);
            if(s != null) s.SetActive(false);
        } else if (isQuizEndToClose)
        {
            canvas.SetActive(false);
        }
        else
        {
            reset();
        }
    }
}
