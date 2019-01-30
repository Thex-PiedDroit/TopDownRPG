
using UnityEngine;


public enum EAttackDirection
{
	FORWARD,
	BACKWARD,
	RIGHT,
	LEFT,
	NONE
}


[System.Serializable]
public class AttackData
{
	public MinMaxRange m_iDamage;
}

[System.Serializable]
public class AssignedAttackData
{
	public EAttackDirection m_eAttackDirection = EAttackDirection.NONE;
	public AttackData m_pData = null;
}
