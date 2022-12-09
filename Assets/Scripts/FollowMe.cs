using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    private Vector3 _offset= Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _camera.position;
    }

    // Update is called once per frame
    // o = a - b
    // o + b = a
    // b = a - o
    void Update()
    {
        if (_camera == null) return;

        _camera.position = transform.position - _offset;
    }
}
