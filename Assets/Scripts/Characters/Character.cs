
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ICharacter, IInputsReceiver
{
#region Variables (public)

	public InputsProxy m_iInputsProxy = null;

	public Rigidbody2D m_pRigidBody = null;

	public float m_fMoveSpeed = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	private void Update()
	{
		UpdateInputsProxy();
	}

	private void LookAt(Vector3 tPosition)
	{
		transform.up = (tPosition - transform.position).normalized;
	}

	private void MoveInDirection(Vector2 tDirection)
	{
		Vector2 tMove = tDirection * (m_fMoveSpeed * Time.deltaTime);
		m_pRigidBody.MovePosition(m_pRigidBody.position + tMove);
	}


#region ICharacter interface

	public Vector2 GetPosition()
	{
		return transform.position;
	}

	public Vector2 GetForward()
	{
		return transform.up;
	}

	#endregion

#region IInputsReceiver interface

	public void PlugInputsProxy(InputsProxy pInputsProxy)
	{
		m_iInputsProxy = pInputsProxy;
	}

	public void UpdateInputsProxy()
	{
		m_iInputsProxy?.UpdateProxy(this);
	}

	public List<AxisInputQuery> GetAxisToCheck()
	{
		return null;	// NOT YET IMPLEMENTED
	}

	public List<string> GetButtonsToCheck()
	{
		return null;	// NOT YET IMPLEMENTED
	}

	public void HandleMouseWorldPos(Vector3 tPosition)
	{
		LookAt(tPosition);
	}

	public void HandleDirectionInputNotNormalized(Vector2 tDirection)
	{
		MoveInDirection(tDirection.normalized);
	}

	public void HandleExtraAxisInput(string sAxisName, float fAxis)
	{
		throw new System.NotImplementedException();
	}

	public void HandleButtonInput(string sButtonName, EInputAction eInputAction)
	{
		throw new System.NotImplementedException();
	}

	#endregion
}
