using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemySense : MonoBehaviour
{

	[SerializeField] float fov = 110f;

	public Vector3 personalLastSighting;

	private bool playerInSight;
	private bool playerHeard;
	private NavMeshAgent nav;
	private SphereCollider col;
	private GameObject player;
	private Player playerScript;

	// Use this for initialization
	void Start()
	{
		nav = GetComponent<NavMeshAgent>();
		player = GameObject.Find("Player");
		playerScript = player.GetComponent<Player>();
		col = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player)
		{
			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);

			if (angle < fov * 0.5f)
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
				{
					if (hit.collider.gameObject == player)
					{
						playerInSight = true;
						personalLastSighting = player.transform.position;
					}
				}
			}

			if (!playerScript.isSneaking)
			{
				if (CalculatePathLength(player.transform.position) <= col.radius)
				{
					playerHeard = true;
					personalLastSighting = player.transform.position;
				}
			}

		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			playerInSight = false;
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
