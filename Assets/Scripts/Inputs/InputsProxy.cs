
using UnityEngine;
using System.Collections.Generic;


// Related data structures are defined in InputsDataStructures.cs

abstract public class InputsProxy : ScriptableObject
{
#region Variables (public)



	#endregion

#region Variables (protected)

	protected List<AxisInputQuery> m_pCachedAxisToCheck = null;
	protected List<string> m_pCachedButtonsToCheck = null;

	#endregion

#region Variables (private)

	private IInputsReceiver m_iCachedInputsReceiver = null;

	#endregion


	public void UpdateProxy(IInputsReceiver pReceiver)
	{
		CacheReceiver(pReceiver);

		CatchMouseWorldPositionInput(pReceiver);
		CatchDirectionInputs(pReceiver);
		CatchExtraAxisInputs(pReceiver);
		CatchButtonsInputs(pReceiver);
	}

	private void CacheReceiver(IInputsReceiver pReceiver)
	{
		if (pReceiver == m_iCachedInputsReceiver)
			return;

		m_iCachedInputsReceiver = pReceiver;
		m_pCachedButtonsToCheck = pReceiver.GetButtonsToCheck();
		m_pCachedAxisToCheck = pReceiver.GetAxisToCheck();
	}

	abstract protected void CatchMouseWorldPositionInput(IInputsReceiver pReceiver);
	abstract protected void CatchDirectionInputs(IInputsReceiver pReceiver);
	abstract protected void CatchExtraAxisInputs(IInputsReceiver pReceiver);
	abstract protected void CatchButtonsInputs(IInputsReceiver pReceiver);
}
