using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jasper : Enemy
{
	public override void AttackStart()
	{
		isAttacking = true;
		playerScript.Ensnare(this.gameObject, true);
	}

	public override void AttackEnd()
	{
		isAttacking = false;
	}

	public override void AttackDamage()
	{
		playerScript.TakeDamage(attackDamage);
		playerScript.Ensnare(this.gameObject, false);
	}
}
