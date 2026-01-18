using UnityEngine;
using TMPro;
using System;

public class TextChanger : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textComponent;

    [SerializeField]
    private ScoreCounter _scoreCounter;

    private void Start() =>
        _textComponent.text = "Нажмите ЛКМ";

    private void ShowText(int value)
    {
        if (_textComponent == null)
            throw new ArgumentNullException($"Нет компонента {nameof(_textComponent)}");

        _textComponent.text = "Счёт: " + value;
    }

    private void OnEnable()
    {
        if (_scoreCounter == null)
            throw new NullReferenceException($"Нет компонента {nameof(_scoreCounter)}");

        _scoreCounter.ScoreChanged += ShowText;
    }

    private void OnDisable() =>
        _scoreCounter.ScoreChanged -= ShowText;
}
