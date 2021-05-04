using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
	public float smoothing = 6.5f;
	public int speedMoveDivider = 70;
	public GameObject terreno;
	public GameObject targetCam;
	private Camera cam;
	private float targetZoom;
	Transform target;
	float x = 0f;
	float y = 0f;

	void Start()
	{
		cam = Camera.main;
		targetZoom = cam.orthographicSize;
	}

	void Update()
	{
		float ScrollWheelChange;
		ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
		targetZoom -= ScrollWheelChange * 4f; // Cantidad de zoom por rueda
		targetZoom = Mathf.Clamp(targetZoom, 5f, 20f); // Limites del zoom
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * 10);
		if (target)
		{ 
			if(Input.GetKey(KeyCode.Space))
			{
				x = 0;
				y = 0;
			}
			else
			{
				x += Input.GetAxisRaw("Horizontal") * targetZoom / speedMoveDivider;
				y += Input.GetAxisRaw("Vertical") * targetZoom / speedMoveDivider;
			}
			if (Input.mousePosition.x <= 15)
			{
				x -= targetZoom / speedMoveDivider;
			}
			else
			{
				if (Input.mousePosition.x >= Screen.width - 15)
				{
					x += targetZoom / speedMoveDivider;
				}
			}
			if (Input.mousePosition.y >= Screen.height - 15)
			{
				y += targetZoom / speedMoveDivider;
			}
			else
			{
				if (Input.mousePosition.y <= 15)
				{
					y -= targetZoom / speedMoveDivider;
				}
			}
			/*
			float xMax = terreno.GetComponent<LevelGenerator>().Map.width / Mathf.Sqrt(targetZoom / 10);
			x = Mathf.Clamp(x, -xMax*0.5f, xMax*0.5f);
			float yMax = terreno.GetComponent<LevelGenerator>().Map.height / Mathf.Sqrt(targetZoom / 10);
			y = Mathf.Clamp(y, -yMax * 0.5f, yMax * 0.5f);*/
			Vector3 targetCamPos = target.position + new Vector3(x, y, -10);
			Vector3 smoothCamPos = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
			transform.position = smoothCamPos;
		}
	}

	public void MovetoTarget(Transform tar)
	{
		target = tar;
		Vector3 targetCamPos = target.position + new Vector3(0, 0, -10);
		transform.position = targetCamPos;
	}
}
