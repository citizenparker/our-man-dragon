using UnityEngine;

public class RandomSpawner {
	private Vector2 center;
	private float minRange;
	private float maxRange;

	public RandomSpawner(Transform center, float minRange, float maxRange) {
		this.center = new Vector2(center.position.x, center.position.z);
		this.minRange = minRange;
		this.maxRange = maxRange;
	}
	
	public RandomSpawner(Vector2 center, float minRange, float maxRange) {
		this.center = center;
		this.minRange = minRange;
		this.maxRange = maxRange;
	}

	public Vector2 NextLocation() {
		var relativePosition = Random.insideUnitCircle * (maxRange - minRange); 
		relativePosition = relativePosition.normalized * (relativePosition.magnitude + minRange);

		var newPoint = new Vector2(
			relativePosition.x + center.x,
			relativePosition.y + center.y
		);

		return newPoint;
	}

	public GameObject Spawn(GameObject original) {
		return Spawn(original, this.NextLocation());
	}

	public GameObject Spawn(GameObject original, Vector2 location) {
		var newObject = (GameObject)GameObject.Instantiate(original);

		newObject.transform.position = new Vector3(
			location.x,
			newObject.transform.position.y,
			location.y
			);
		
		return newObject;
	}
}