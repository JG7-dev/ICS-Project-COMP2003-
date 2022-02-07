using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable_Objects/Movement/Settings")]
public class MoveSettings : ScriptableObject
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 13.0f;
    [SerializeField] private float _antiBump = 4.5f;
    [SerializeField] private float _gravity = 30.0f;

    public float speed
    {
        get => _speed;
        private set => _speed = value;
    }

    public float jumpForce
    {
        get => _jumpForce;
        private set => _jumpForce = value;
    }

    public float antiBump
    {
        get => _antiBump;
        private set => _antiBump = value;
    }

    public float gravity
    {
        get => _gravity;
        private set => _gravity = value;
    }
}