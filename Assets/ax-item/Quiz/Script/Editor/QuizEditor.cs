using VRC.Udon;
using UnityEditor;
using UnityEngine;
using UdonSharpEditor;
using System;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(Quiz))]
public class QuizEditor : Editor
{

    private const string defineTxt = "UDON_CHIPS";

    enum ModeTab
    {
        NormalMode,
        MaxMode
    }

    private ModeTab currentModeTab;
    bool[] isOpenArray = { false, false, false, false };
    bool debugOpen = false;

    public override void OnInspectorGUI()
    {
        if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target)) return;
        EditorGUILayout.LabelField("ScriptingDefineSymbols");
        Quiz targetQuiz = (Quiz)target;
        if (CheckDefineSymbol(defineTxt))
        {
            if (GUILayout.Button("UdonChipsの無効化"))
            {
                RemoveDefineSymbols(defineTxt);
            }
        }
        else
        {
            if (GUILayout.Button("UdonChipsの有効化"))
            {
                AddDefineSymbols(defineTxt);
            }
        }
        printLabel("？ クイズ設定", Color.black, new Color(0, 0, 0, 0), 14);
        currentModeTab = (ModeTab)GUILayout.Toolbar(targetQuiz.maxMode?1:0, Enum.GetNames(typeof(ModeTab)));
        if (currentModeTab.Equals(ModeTab.MaxMode))
        {
            targetQuiz.maxQuestion = EditorGUILayout.IntField("出題数", targetQuiz.maxQuestion);
            targetQuiz.requie_answer = EditorGUILayout.IntField("合格認定正解数", targetQuiz.requie_answer);
            targetQuiz.maxMode = true;
        }
        else
        {
            currentModeTab = ModeTab.NormalMode;
            targetQuiz.requie_answer = EditorGUILayout.IntField("必須正解数", targetQuiz.requie_answer);
            targetQuiz.ignore_incorrect = EditorGUILayout.IntField("許容誤答数", targetQuiz.ignore_incorrect);
            targetQuiz.maxMode = false;
        }
        hr();
        printLabel("◆ 表示設定", Color.black, new Color(0, 0, 0, 0), 14);
        targetQuiz.isCommentary = EditorGUILayout.Toggle("解説の表示", targetQuiz.isCommentary);
        targetQuiz.isResult = EditorGUILayout.Toggle("最終成績の表示", targetQuiz.isResult);
        targetQuiz.isQuizEndToText = EditorGUILayout.Toggle("終了後にテキストのみ表示", targetQuiz.isQuizEndToText);
        if(!targetQuiz.isQuizEndToText){
            targetQuiz.isQuizEndToClose = EditorGUILayout.Toggle("終了後にウィンドウを非表示", targetQuiz.isQuizEndToClose);
        }
        targetQuiz.isScoreView = EditorGUILayout.Toggle("スコアの表示", targetQuiz.isScoreView);
        targetQuiz.success_text = EditorGUILayout.TextField("合格時テキスト", targetQuiz.success_text);
        targetQuiz.failed_text = EditorGUILayout.TextField("不合格時テキスト", targetQuiz.failed_text);
        if (CheckDefineSymbol(defineTxt))
        {
            hr();
            printLabel("＄ UdonChips", Color.black, new Color(0, 0, 0, 0), 14);
            targetQuiz.isScore2Money = EditorGUILayout.Toggle("スコアをそのまま支払う", targetQuiz.isScore2Money);
            if(targetQuiz.isScore2Money){
                targetQuiz.isAllOKOnly2Pay = EditorGUILayout.Toggle("合格認定時のみスコアを支払う", targetQuiz.isAllOKOnly2Pay);
            }
        }
        hr();
        printLabel("◆ 正解時", Color.black, new Color(0, 0, 0, 0), 14);
        targetQuiz.correct_audio = (AudioSource)EditorGUILayout.ObjectField("サウンド", targetQuiz.correct_audio, typeof(AudioSource), true);
        hr();
        printLabel("◆ 結果表示 - 合格", Color.black, new Color(0, 0, 0, 0), 14);
        targetQuiz.allOK_audio = (AudioSource)EditorGUILayout.ObjectField("サウンド", targetQuiz.allOK_audio, typeof(AudioSource), true);
        isOpenArray[0] = EditorGUILayout.Foldout(isOpenArray[0], "有効化オブジェクト");
        if (isOpenArray[0])
        {
            GameObjectField(ref targetQuiz.allOK_enableObject);
        }
        isOpenArray[1] = EditorGUILayout.Foldout(isOpenArray[1], "無効化オブジェクト");
        if (isOpenArray[1])
        {
            GameObjectField(ref targetQuiz.allOK_disableObject);
        }
        targetQuiz.allOK_Udon = (UdonBehaviour)EditorGUILayout.ObjectField("Udon", targetQuiz.allOK_Udon, typeof(UdonBehaviour), true);
        targetQuiz.allOK_Udon_MethodName = EditorGUILayout.TextField("UdonMethod", targetQuiz.allOK_Udon_MethodName);
        if (CheckDefineSymbol(defineTxt)) targetQuiz.allOK_TakeMoney = EditorGUILayout.FloatField("UC : 支払い金額", targetQuiz.allOK_TakeMoney);
        hr();
        printLabel("◆ 不正解時", Color.black, new Color(0, 0, 0, 0), 14);
        targetQuiz.incorrect_audio = (AudioSource)EditorGUILayout.ObjectField("サウンド", targetQuiz.incorrect_audio, typeof(AudioSource), true);
        hr();
        printLabel("◆ 結果表示 - 不合格", Color.black, new Color(0, 0, 0, 0), 14);
        targetQuiz.failed_audio = (AudioSource)EditorGUILayout.ObjectField("サウンド", targetQuiz.failed_audio, typeof(AudioSource), true);
        isOpenArray[2] = EditorGUILayout.Foldout(isOpenArray[2], "有効化オブジェクト");
        if (isOpenArray[2])
        {
            GameObjectField(ref targetQuiz.incorrect_enableObject);
        }
        isOpenArray[3] = EditorGUILayout.Foldout(isOpenArray[3], "無効化オブジェクト");
        if (isOpenArray[3])
        {
            GameObjectField(ref targetQuiz.incorrect_disableObject);
        }
        targetQuiz.incorrect_Udon = (UdonBehaviour)EditorGUILayout.ObjectField("Udon", targetQuiz.incorrect_Udon, typeof(UdonBehaviour), true);
        targetQuiz.incorrect_Udon_MethodName = EditorGUILayout.TextField("UdonMethod", targetQuiz.incorrect_Udon_MethodName);
        if (CheckDefineSymbol(defineTxt)) targetQuiz.incorrect_TakeMoney = EditorGUILayout.FloatField("UC : 支払い金額", targetQuiz.incorrect_TakeMoney);
        EditorGUILayout.Space();
        debugOpen = EditorGUILayout.Foldout(debugOpen, "(従来のinspector)");
        if (debugOpen)
        {
            base.OnInspectorGUI();
        }
    }

    void GameObjectField(ref GameObject[] objects)
    {
        int listSize = objects.Length;
        listSize = EditorGUILayout.IntField("Size", listSize);
        if (listSize != objects.Length)
        {
            System.Array.Resize(ref objects, listSize);
        }
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = (GameObject)EditorGUILayout.ObjectField("Element " + i, objects[i], typeof(GameObject), true);
        }
    }

    List<string> getDefineSymbols()
    {
        return new List<string>(PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(';'));
    }

    bool CheckDefineSymbol(string symbols)
    {
        return getDefineSymbols().Contains(symbols);
    }

    void AddDefineSymbols(string defineSymbol)
    {
        List<string> symbols = getDefineSymbols();
        if (!symbols.Contains(defineSymbol))
        {
            symbols.Add(defineSymbol);
            SetDefineSymbols(symbols);
        }
    }

    void RemoveDefineSymbols(string defineSymbol)
    {
        List<string> symbols = getDefineSymbols();
        if (symbols.Contains(defineSymbol))
        {
            symbols.Remove(defineSymbol);
            SetDefineSymbols(symbols);
        }
    }

    void SetDefineSymbols(List<string> defineSymbols)
    {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(
                EditorUserBuildSettings.selectedBuildTargetGroup,
                string.Join(";", defineSymbols)
            );
    }

    void hr()
    {
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
    }

    void printLabel(string text, Color textColor, Color backColor, int fontSize, FontStyle fontStyle = FontStyle.Bold)
    {
        Color beforeBackColor = GUI.backgroundColor;
        GUIStyle guiStyle = new GUIStyle();
        GUIStyleState styleState = new GUIStyleState();
        styleState.textColor = textColor;
        styleState.background = Texture2D.whiteTexture;
        GUI.backgroundColor = backColor;
        guiStyle.normal = styleState;
        guiStyle.fontSize = fontSize;
        GUILayout.Label(text, guiStyle); //labelFieldだとうまくいかない？
        GUI.backgroundColor = beforeBackColor;
    }

}