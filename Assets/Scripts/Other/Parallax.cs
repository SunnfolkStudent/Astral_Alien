using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _length, _startpos;

    public GameObject camera;
    public float parallaxEffect;
    
   
    private void Start()
    {
        _startpos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    private void FixedUpdate()
    {
        float temp = (camera.transform.position.x * (1 - parallaxEffect));
        float distance = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(_startpos + distance, transform.position.y, transform.position.z);

        if (temp > _startpos + _length)
        {
            _startpos += _length;
        } else if (temp < _startpos - _length)
        {
            _startpos -= _length;
        }
    }
}
