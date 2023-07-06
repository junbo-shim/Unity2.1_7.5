using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 래핑할 메서드의 필요 전처리기
using UnityEngine.UI;
// 래핑할 메서드의 필요 전처리기
using UnityEngine.SceneManagement;

public static partial class Function_Global
{
    //래핑할 전처리기를 표시
    [System.Diagnostics.Conditional("DEBUG_MODE")]

    //Log 래핑
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    //
    public static void Assert(bool condition) 
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject 받아서 Text 찾아서 text 필드 값 수정하는 함수, text를 사용하기 위해서는 using UnityEngine.UI 써야함
    public static void SetText(this GameObject target, string text) 
    {
        Text textcomponent = target.GetComponent<Text>();
        if(textcomponent == null || textcomponent == default) 
        {
            return;
        }

        textcomponent.text = text;
    } 

    // ! LoadScene 함수의 래핑
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
