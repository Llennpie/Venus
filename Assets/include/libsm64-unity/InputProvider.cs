using UnityEngine;
using LibSM64;

public class InputProvider : SM64InputProvider
{
    Transform cameraObject = null;

    void Start()
    {
        cameraObject = Camera.main.transform;
    }

    public override Vector3 GetCameraLookDirection()
    {
        return cameraObject.forward;
    }

    public override Vector2 GetJoystickAxes()
    {
        return new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );
    }

    public override bool GetButtonHeld( Button button )
    {
        switch( button )
        {
            case SM64InputProvider.Button.Jump:  return Input.GetButton("Jump");
            case SM64InputProvider.Button.Kick:  return Input.GetButton("Kick");
            case SM64InputProvider.Button.Stomp: return Input.GetButton("Z");
        }
        return false;
    }

    public override bool GetAxisHeld(string axis)
    {
        return Input.GetAxis(axis) > 0 || Input.GetButton(axis);
    }
}