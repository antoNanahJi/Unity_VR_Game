using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private Transform[] waypoints = new Transform[4];
	[SerializeField] protected GameObject head;
	[SerializeField] protected float fov;
	[SerializeField] protected float sightRangeModifier;
	[SerializeField] protected float runSpeed;
	[SerializeField] protected float walkSpeed;
	[SerializeField] protected float attackRange;
	[SerializeField] protected int attackDamage;

	[SerializeField] protected Vector3 personalLastSighting;
	[SerializeField] protected bool playerInSight;
	[SerializeField] protected bool playerHeard;

	protected Animator anim;
	protected NavMeshAgent nav;
	protected SphereCollider col;
	protected GameObject player;
	protected Player playerScript;
	protected float actionTimer;
	protected bool actionWait;
	protected bool isAttacking;
	protected Vector3 nullVector;

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

	public virtual void AttackStart()
	{
	}

	public virtual  void AttackEnd()
	{
	}

	public virtual void AttackDamage()
	{
	}

	/*
	void OnAnimatorMove()
	{
		// for root motion movement
		nav.speed = (anim.deltaPosition / Time.deltaTime).magnitude;
	}
	*/

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

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player)
		{
			playerInSight = false;

			Vector3 direction = other.transform.position - head.transform.position;
			float angle = Vector3.Angle(direction, head.transform.forward);

			if (angle < fov * 0.5f)
			{
				RaycastHit hit;
				if (Physics.Raycast(head.transform.position + transform.up, direction.normalized, out hit, col.radius * sightRangeModifier))
				{
					if (hit.collider.gameObject == player)
					{
						playerInSight = true;
						personalLastSighting = player.transform.position;
					}
				}
			}

			if (!playerScript.isSneaking && playerScript.isWalking)
			{
				if (CalculatePathLength(player.transform.position) <= col.radius)
				{
					playerHeard = true;
					personalLastSighting = player.transform.position;
				}
				else
				{
					playerHeard = false;
				}
			}
			else
			{
				playerHeard = false;
			}

		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			playerInSight = false;
			playerHeard = false;
		}
	}

	float CalculatePathLength(Vector3 targetPosition) // For sound detection through walls
	{
		NavMeshPath path = new NavMeshPath();
		if (nav.enabled)
		{
			nav.CalculatePath(targetPosition, path);
		}
		Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

		allWayPoints[0] = transform.position;
		allWayPoints[allWayPoints.Length - 1] = targetPosition;

		for (int i = 0; i < path.corners.Length; i++)
		{
			allWayPoints[i + 1] = path.corners[i];
		}

		float pathLength = 0f;

		for (int i = 0; i < allWayPoints.Length - 1; i++)
		{
			pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
		}
		return pathLength;
	}
}
