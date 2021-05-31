using UnityEngine;
using LibSM64;

public class NoInput : SM64InputProvider
{
    public override Vector3 GetCameraLookDirection()
    {
        return Vector3.zero;
    }

    public override Vector2 GetJoystickAxes()
    {
        return Vector2.zero;
    }

    public override bool GetButtonHeld( Button button )
    {
        return false;
    }
}