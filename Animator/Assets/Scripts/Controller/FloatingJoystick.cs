using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
	[SerializeField] private Image _imgHandleDirection = null;
	[SerializeField] private GameObject _goDesc;

	protected override void Start()
	{
		base.Start();
		SetView(false);
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
		base.OnPointerDown(eventData);
		SetView(true);
	}

	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);
		_imgHandleDirection.gameObject.SetActive(!handle.anchoredPosition.AlmostEquals(Vector3.zero));

		if (!handle.anchoredPosition.AlmostEquals(Vector3.zero))
		{
			var stDirection = (Vector2)handle.anchoredPosition;
			_imgHandleDirection.rectTransform.up = stDirection.normalized;
		}
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		background.gameObject.SetActive(false);
		base.OnPointerUp(eventData);
		SetView(false);
	}

	void SetView(bool state)
    {
		background.gameObject.SetActive(state);
		_goDesc.SetActive(!state);
	}
}