using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private int _record;

    private void OnEnable()
    {
        _player.ScoreChanged += ScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= ScoreChanged;
    }

    public void Show()
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1);
    }

    public void Hide()
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0);
        _text.text = "Record: " + _record;
    }

    private void ScoreChanged(int score)
    {
        if (score > _record)
        {
            _record = score;
            _text.text = "New record!!!";
        }
    }

}
