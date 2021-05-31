using System;
using UnityEngine;
using LibSM64;

public class MachinimaCamera : MonoBehaviour
{
    public enum CameraMode {
        Normal, Fixed
    };
    public CameraMode currentCameraMode;

    [SerializeField] GameObject target = null;
    [SerializeField] float radius = 15;
    [SerializeField] float elevation = 5;

    void Start() {
        currentCameraMode = CameraMode.Normal;
    }

    void LateUpdate()
    {
        var m = target.transform.position;
        var n = transform.position;
        m.y = 0;
        n.y = 0;
        n = (n - m).normalized * radius;
        n = Quaternion.AngleAxis( Input.GetAxis("HorizontalCam") * Time.deltaTime * 125f, Vector3.up ) * n;
        n += m;
        n.y = target.transform.position.y + elevation;
        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y + 1, target.transform.position.z);

        if (Input.GetAxis("VerticalCam") > 0.25f || Input.GetAxis("VerticalCam") < -0.25f) {
            if (elevation >= 0.175f && elevation <= 50f) {
                elevation -= (Input.GetAxis("VerticalCam")) * Time.deltaTime * 12.5f;
            }
            if (elevation < 0.175f) { elevation = 0.175f; }
            if (elevation > 50f) { elevation = 50f; }
        }

        // Camera Modes

        if (currentCameraMode == CameraMode.Normal) {
            transform.position = n;
            transform.LookAt(targetPos);
        }
        if (currentCameraMode == CameraMode.Fixed) {
            // nothing yet   
        }

        if (Input.GetButtonDown("R")) {
            if (currentCameraMode == CameraMode.Normal) {
                currentCameraMode = CameraMode.Fixed;
            } else if (currentCameraMode == CameraMode.Fixed) {
                currentCameraMode = CameraMode.Normal;
            }
        }
    }
}
