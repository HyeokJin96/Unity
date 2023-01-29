using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static partial class GFunc
{
    public static void SetTxt(GameObject obj_, string text_)
    {
        Text txt = obj_.GetComponent<Text>();

        if (txt == null || txt == default(Text))
        {
            return;
        }

        txt.text = text_;
    }   //  SetTxt()
}
