using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claire : Enemy
{
	public override void AttackStart()
	{
		isAttacking = true;
		playerScript.Ensnare(true);
	}

	public override void AttackEnd()
	{
		isAttacking = false;
	}

	public override void AttackDamage()
	{
		playerScript.TakeDamage(attackDamage);
		playerScript.Ensnare(false);
	}
}
