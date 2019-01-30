
using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
#region Variables (public)

	public List<AssignedAttackData> m_pAttacksData = null;

	#endregion


	public AttackData GetAttackData(EAttackDirection eAttackDirection)
	{
		for (int i = 0; i < m_pAttacksData.Count; ++i)
		{
			if (m_pAttacksData[i].m_eAttackDirection == eAttackDirection)
				return m_pAttacksData[i].m_pData;
		}

		return null;
	}
}
