
using UnityEngine;


[CreateAssetMenu(fileName = "HardwareInputsProxy", menuName = "Inputs Proxys/Hardware Inputs Proxy (for player)")]
public class HardwareInputsProxy : InputsProxy
{
#region Variables (public)

	// If need of inputs modifiers later in development, put them here as plug-ins

	#endregion

#region Variables (private)



	#endregion


	override protected void CatchMouseWorldPositionInput(IInputsReceiver pReceiver)
	{
		pReceiver.HandleMouseWorldPos(GameManager.Instance.CurrentCamera.ScreenToWorldPoint(Input.mousePosition).SetZ(0.0f));
	}

	override protected void CatchDirectionInputs(IInputsReceiver pReceiver)
	{
		float fHorizontal = Input.GetAxis("Horizontal");
		float fVertical = Input.GetAxis("Vertical");

		if (fHorizontal != 0.0f || fVertical != 0.0f)
			pReceiver.HandleDirectionInputNotNormalized(new Vector2(fHorizontal, fVertical));
	}

	override protected void CatchExtraAxisInputs(IInputsReceiver pReceiver)
	{
		if (m_pCachedAxisToCheck == null)
			return;

		for (int i = 0; i < m_pCachedAxisToCheck.Count; ++i)
		{
			AxisInputQuery tAxisQuery = m_pCachedAxisToCheck[i];
			string sAxisName = tAxisQuery.m_sAxisName;

			float fAxisValue = tAxisQuery.m_bQueryRaw ? Input.GetAxisRaw(sAxisName) : Input.GetAxis(sAxisName);

			if (fAxisValue != 0.0f)
				pReceiver.HandleExtraAxisInput(sAxisName, fAxisValue);
		}
	}

	override protected void CatchButtonsInputs(IInputsReceiver pReceiver)
	{
		if (m_pCachedButtonsToCheck == null)
			return;

		for (int i = 0; i < m_pCachedButtonsToCheck.Count; ++i)
		{
			string sButtonName = m_pCachedButtonsToCheck[i];

			if (Input.GetButtonDown(sButtonName))
				pReceiver.HandleButtonInput(sButtonName, EInputAction.DOWN);
			else if (Input.GetButton(sButtonName))
				pReceiver.HandleButtonInput(sButtonName, EInputAction.HELD);
			else if (Input.GetButtonUp(sButtonName))
				pReceiver.HandleButtonInput(sButtonName, EInputAction.UP);
		}
	}
}
