using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform _DummyTransform, _tCharacter;

    public float _fCamHeight = 7f;
    public float _fCamForward = -7f;

    public bool _isAuto = true;
    public bool _isBack = false;

    Transform _tarTransform;

    private void Awake()
    {
        _tarTransform = transform;
    }

    public void LateUpdate()
    {
        if ( _isAuto )
        {
            if (null != _DummyTransform && !_isBack)
            {
                _tarTransform.position = _DummyTransform.position
                                         + _DummyTransform.forward * _fCamForward
                                         + _DummyTransform.up * _fCamHeight;

                transform.position = Vector3.MoveTowards(transform.position, _tarTransform.position, 0.1f);
                transform.LookAt(_DummyTransform);
            }
            else if (null != _tCharacter && _isBack)
            {
                Camera.main.fieldOfView = 55f;
                transform.position = _tCharacter.position
                                     + new Vector3(1f, 1.5f, -3.5f);
                transform.LookAt(transform.position
                                 + new Vector3(0, 0, 1f));
            }
        }
    }
}
