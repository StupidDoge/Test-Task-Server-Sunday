using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageObject : MonoBehaviour
{
    private RawImage _image;
    [SerializeField] private int _id;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    public void SetImageId(int id)
    {
        _id = id;
    }
}
