using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectiles : MonoBehaviour
{

	[SerializeField]
	int numberOfProjectiles;

	[SerializeField]
	GameObject projectile;

	Vector2 startPoint;

	float radius, moveSpeed;

	// Use this for initialization
	void Start()
	{
		radius = 5f;
		moveSpeed = 5f;
	}

	public void attack()
    {


		startPoint = transform.position;
		SpawnProjectiles(numberOfProjectiles);
		
	}
	public void attack(int numberOfProjectiles)
	{
		

		startPoint = transform.position;
		SpawnProjectiles(numberOfProjectiles);

	}
	public void attack(int numberOfProjectiles, GameObject projectile)
	{
		
		this.projectile = projectile;

		startPoint = transform.position;
		SpawnProjectiles(numberOfProjectiles);

	}



	void SpawnProjectiles(int numberOfProjectiles)
	{
		float angleStep = 360f / numberOfProjectiles;
		float angle = 0f;

		for (int i = 0; i <= numberOfProjectiles - 1; i++)
		{

			float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius *2;
			float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius *2;

			Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = Instantiate(projectile, startPoint, Quaternion.identity);
			proj.GetComponent<Rigidbody2D>().velocity =
				new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

			angle += angleStep;
		}
	}

}