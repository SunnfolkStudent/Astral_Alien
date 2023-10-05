using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _length, _startPos;
    public GameObject camera;
    public float parallaxEffect;

    private void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = (camera.transform.position.x * (1 - parallaxEffect));
        float distance = (camera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);

        if (temp > _startPos + _length)
        {
            _startPos += _length;
        } else if (temp < _startPos - _length)
        {
            _startPos -= _length;
        }
    }
}
