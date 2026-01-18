using UnityEngine;

public class InputHeader : MonoBehaviour
{
    private bool _isActive = false;

    public event System.Action<bool> IsChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        if (_isActive)
            _isActive = false;
        else
            _isActive = true;

        IsChanged.Invoke(_isActive);
    }
}
