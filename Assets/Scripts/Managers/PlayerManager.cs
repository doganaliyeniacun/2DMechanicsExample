using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static event Action<Vector2> MoveEvents;

    public static event Action JumpEvents;

    public static event Action DashEvents;

    private void OnMove(InputValue input)
    {
        MoveEvents?.Invoke(input.Get<Vector2>());
    }

    private void OnJump()
    {
        JumpEvents?.Invoke();
    }

    private void OnDash()
    {
        DashEvents?.Invoke();
    }
}
