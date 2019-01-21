
using UnityEngine;
using System.Collections.Generic;


public enum EInputAction
{
	DOWN,
	HELD,
	UP,
	NONE
}

[System.Serializable]
public struct AxisInputQuery
{
	public string m_sAxisName;
	public bool m_bQueryRaw;


	public AxisInputQuery(string sAxisName, bool bQueryRaw)
	{
		m_sAxisName = sAxisName;
		m_bQueryRaw = bQueryRaw;
	}
}

public interface IInputsReceiver
{
	void PlugInputsProxy(InputsProxy pInputsProxy);
	void UpdateInputsProxy();

	List<AxisInputQuery> GetAxisToCheck();
	List<string> GetButtonsToCheck();

	void HandleMouseWorldPos(Vector3 tPosition);
	void HandleDirectionInputNotNormalized(Vector2 tDirection);
	void HandleExtraAxisInput(string sAxisName, float fAxis);
	void HandleButtonInput(string sButtonName, EInputAction eInputAction);
}
