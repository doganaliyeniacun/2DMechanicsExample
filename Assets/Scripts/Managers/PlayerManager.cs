using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static event Action<Vector2> MoveEvents;

    public static event Action JumpEvents;

    public static event Action DashEvents;
    public static event Action AttackEvents;

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
    
    private void OnAttack()
    {   
        AttackEvents?.Invoke();
    }
}
