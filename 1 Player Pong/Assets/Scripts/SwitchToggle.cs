using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
	public static bool vibration = true;
	public Toggle toggle;
	[SerializeField] RectTransform toggleHandleRectTransform;
	[SerializeField] Color bgActiveColor;
	[SerializeField] Color handleActiveColor;
	Color bgDefaultColor, handleDefaultColor;
	Image bgImage, handleImage;
	public Vector2 handlePos;

	void Awake()
	{
		toggle = GetComponent<Toggle>();
		handlePos = toggleHandleRectTransform.anchoredPosition;
		bgImage = toggleHandleRectTransform.parent.GetComponent<Image>();
		handleImage = toggleHandleRectTransform.GetComponent<Image>();
		bgDefaultColor = bgImage.color;
		handleDefaultColor = handleImage.color;

		toggle.onValueChanged.AddListener(OnSwitch);

		toggle.isOn = vibration;

		if (toggle.isOn)
		{
			OnSwitch(true);
		}
	}

	void OnSwitch(bool on)
	{
		if (on)
		{
			toggleHandleRectTransform.anchoredPosition = handlePos * -1;
			bgImage.color = bgActiveColor;
			handleImage.color = handleActiveColor;
			vibration = true;
			Handheld.Vibrate();
		}
		else
		{
			toggleHandleRectTransform.anchoredPosition = handlePos;
			bgImage.color = bgDefaultColor;
			handleImage.color = handleDefaultColor;
			vibration = false;
		}
	}

	void OnDestroy()
	{
		toggle.onValueChanged.RemoveListener(OnSwitch);
	}
}
