using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private InputHeader _inputHeader;

    private const float IncreaseValue = 0.5f;

    private bool _isActive;
    private int _score = 0;
    private float _timer = 0f;

    public event Action<int> ScoreChanged;

    private void Update() =>
        TryIncreaseScore();

    private void TryIncreaseScore()
    {
        if (_isActive == false)
            return;

        _timer += Time.deltaTime;

        if (_timer >= IncreaseValue)
        {
            _score++;
            _timer -= IncreaseValue;

            ScoreChanged.Invoke(_score);
        }
    }

    private void OnInputChanged(bool isActive) =>
        _isActive = isActive;

    private void OnEnable()
    {
        if (_inputHeader == null)
            throw new ArgumentNullException($"Нет компонента {nameof(_inputHeader)}");

        _inputHeader.IsChanged += OnInputChanged;
    }

    private void OnDisable() =>
        _inputHeader.IsChanged -= OnInputChanged;
}
