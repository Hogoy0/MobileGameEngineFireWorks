using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CamDummy : MonoBehaviour
{
	[SerializeField] CameraMove _cam;
	[SerializeField]GameObject _Player;

	Transform _targetTransform;
	Vector3 _vec = Vector3.zero;

	public float _fDistance = 2f;

	public void Update()
	{
		_targetTransform = _Player.transform;
		Vector3 vDestPos = _targetTransform.position + _targetTransform.forward * _fDistance;

		transform.SetPositionAndRotation(Vector3.SmoothDamp(transform.position, vDestPos, ref _vec, 0.5f, Mathf.Infinity, Time.deltaTime), Quaternion.identity);
	}
}
