using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Paralax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        float newX = _image.uvRect.x + _speed * Time.deltaTime;
        _image.uvRect = new Rect(newX, _image.uvRect.y, _image.uvRect.width, _image.uvRect.height);

        if (Mathf.Abs(newX) > 100)
            _image.uvRect = new Rect(0, _image.uvRect.y, _image.uvRect.width, _image.uvRect.height);
    }
}
