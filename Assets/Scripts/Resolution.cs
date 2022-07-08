using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Vector2 _defaultResolution = new Vector2(Screen.width, Screen.height);

    private void Start()
    {
        float targetAspect = _defaultResolution.x / _defaultResolution.y;
        float initialFov = _camera.fieldOfView;
        float horizontalFov = CalcVerticalFov(initialFov, 1 / targetAspect);
        _camera.fieldOfView = CalcVerticalFov(horizontalFov, _camera.aspect);
    }

    private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;
        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);
        return vFovInRads * Mathf.Rad2Deg;
    }
}
