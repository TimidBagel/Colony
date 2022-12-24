using UnityEngine;

/*
 * DO NOT FORMAT THIS SCRIPT
 */

public class CameraController : MonoBehaviour
{
	private Camera cam;

	private Vector3 dragStartPosition;
	private Vector3 dragCurrentPosition;
	private Vector3 newPosition;

	//	- camera lerp rate
	[SerializeField] private float moveSpeed = 10f;

	[SerializeField] private float targetCameraSize = 10f;
	[SerializeField] private float cameraZoomRate = 10f;
	[SerializeField] private float maxCameraZoom = 40f;
	[SerializeField] private float minCameraZoom = 1f;
	[SerializeField] private float zoomScrollRate = 30f;

//  - init
	private void Start()
	{
		newPosition = transform.position;
		cam = Camera.main;
	}

//	- Loop function
	private void Update()
	{
		HandleDrag();
		HandleZoom();
	}

//	Handles mouse input and drag computations
	private void HandleDrag()
	{
//		- if right click pressed: 
		if (Input.GetMouseButtonDown(1))
		{
//			- store current mouse position in Vector3
			dragStartPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		}

//		- if right click still held: 
		if (Input.GetMouseButton(1))
		{
//			- store current mouse position in Vector3
			dragCurrentPosition = cam.ScreenToWorldPoint(Input.mousePosition);

//			- store difference between mouse positions in Vector3
			newPosition = transform.position + dragStartPosition - dragCurrentPosition;
		}

//		- lerp camera transform to new Vector3 position
		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveSpeed);
	}

	private void HandleZoom()
	{
//		- changes camera size target based on scroll wheel movement
		if (Input.mouseScrollDelta.y != 0)
			targetCameraSize -= Input.mouseScrollDelta.y * zoomScrollRate * Time.deltaTime * 10;
		
		if (targetCameraSize <= minCameraZoom)
			targetCameraSize = minCameraZoom;
		
		if (targetCameraSize >= maxCameraZoom)
			targetCameraSize = maxCameraZoom;
		
		if (cam.orthographicSize < minCameraZoom)
			cam.orthographicSize = minCameraZoom;
		
		if (cam.orthographicSize > maxCameraZoom)
			cam.orthographicSize = maxCameraZoom;

//		- gradually increases and decreases the camera size based on altered camera size target variable over time
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetCameraSize, Time.deltaTime * cameraZoomRate);
	}
}