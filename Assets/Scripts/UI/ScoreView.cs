using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private Color _initialColor;

    private void Start()
    {
        _initialColor = _text.color;
    }

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    public void SetAlpha(float alpha)
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, alpha);
    }

    public void ResetAlpha()
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _initialColor.a);
    }

    private void OnScoreChanged(int score)
    {
        _text.text = score.ToString();
    }
}
