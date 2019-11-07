using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform cameraSpot;
	[SerializeField] private float smooth;

	private void LateUpdate()
	{
		var target = cameraSpot.position;
		target.z = transform.position.z;
		transform.position = Vector3.Lerp(transform.position, target, smooth * Time.deltaTime);
	}
}
