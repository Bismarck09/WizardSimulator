using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.transform.forward);
    }
}
