﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textObj = default;
    private float _feedTime = 0.1f; // 文字送り時間
    private float _t = 0f;
    private int _visibleLen = 0;
    private int _textLen = 0;

    //テキストを設定
    public void SetText(string text)
    {
        textObj.text = text;
        _textLen = text.Length;
        _visibleLen = 0;
        _t = 0;
        textObj.maxVisibleCharacters = 0; // 表示文字数を０に
    }

    private void Update()
    {
        if (_visibleLen < _textLen)
        {
            _t += Time.deltaTime;
            if (_t >= _feedTime)
            {
                _t -= _feedTime;
                _visibleLen++;
                textObj.maxVisibleCharacters = _visibleLen; // 表示を1文字ずつ増やす
            }
        }
    }
}