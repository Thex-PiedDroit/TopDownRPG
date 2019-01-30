
using UnityEngine;


// Related data structures are defined in AttacksDataStructures.cs

public class WeaponsHandler : MonoBehaviour
{
#region Variables (public)

	public Animator m_pAnimator = null;

	#endregion

#region Variables (private)

	private bool m_bCanAttack = true;

	#endregion


	/// <summary>
	/// Used when an attack starts, to prevent ghost triggers.
	/// </summary>
	public void DisableAttack()
	{
		m_bCanAttack = false;
	}

	/// <summary>
	/// Should be called by animations only.
	/// Called towards the end of an attack, to allow inputs catching for combo.
	/// </summary>
	public void _ANIM_EVENT_EnableAttack()
	{
		m_bCanAttack = true;
	}

	public void TryTriggerAttack(bool bRightHand, EAttackDirection eDirection)
	{
		if (m_bCanAttack)
			TriggerAttack(bRightHand, eDirection);
	}

	private void TriggerAttack(bool bRightHand, EAttackDirection eDirection)
	{
		DisableAttack();

		m_pAnimator.SetBool("RightHand", bRightHand);
		InitDirectionsBools(eDirection);


		m_pAnimator.SetTrigger("Attack");
	}

	private void InitDirectionsBools(EAttackDirection eDirection)
	{
		m_pAnimator.SetBool("Forward", false);
		m_pAnimator.SetBool("Right", false);
		m_pAnimator.SetBool("Left", false);
		m_pAnimator.SetBool("Backward", false);

		switch (eDirection)
		{
			case EAttackDirection.FORWARD:
				m_pAnimator.SetBool("Forward", true);
				break;
			case EAttackDirection.RIGHT:
				m_pAnimator.SetBool("Right", true);
				break;
			case EAttackDirection.LEFT:
				m_pAnimator.SetBool("Left", true);
				break;
			case EAttackDirection.BACKWARD:
				m_pAnimator.SetBool("Backward", true);
				break;
		}
	}
}
