using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Claire : Enemy
{
	[SerializeField] private Transform[] waypoints = new Transform[4];
	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent<Player>();
		col = GetComponent<SphereCollider>();
		nullVector = new Vector3(999f, 999f, 999f);
		personalLastSighting = nullVector;
	}

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

	void Update()
	{
		if (playerInSight)
		{
			if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
			{
				anim.SetBool("Attack", true);
			}
			else
			{
				anim.SetBool("Attack", false);
				if (!isAttacking)
				{
					nav.speed = runSpeed;
					nav.SetDestination(player.transform.position);
				}
			}
		}
		else
		{
			if (personalLastSighting != nullVector)
			{
				nav.speed = walkSpeed;
				nav.SetDestination(personalLastSighting);
				personalLastSighting = nullVector;
			}
			else
			{
				if (nav.velocity.magnitude == 0.0f)
				{
					if (!actionWait)
					{
						actionTimer = 2.0f + Random.value * 6.0f;
						actionWait = true;
					}
					else
					{
						if (actionTimer > 0)
						{
							actionTimer -= Time.deltaTime;
						}
						else
						{
							int rand = Random.Range(0, waypoints.Length);
							nav.speed = walkSpeed;
							nav.SetDestination(waypoints[rand].position);
							actionWait = false;
						}
					}
				}
			}
		}
		if (nav.velocity.magnitude > 0.0f)
		{
			anim.SetFloat("MoveSpeed", nav.velocity.magnitude / runSpeed);
		}
		else
		{
			anim.SetFloat("MoveSpeed", 0.0f);
		}
	}

	void LateUpdate()
	{
		if (personalLastSighting != nullVector)
		{
			head.transform.LookAt(personalLastSighting);
		}
	}
}
