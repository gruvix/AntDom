using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
	public float smoothing = 6.5f;
	public int speedMoveDivider = 70;
	public GameObject terreno;
	public Transform targetCam;
	private Camera cam;
	private float targetZoom;
	Transform target;

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
				targetCam.transform.position = new Vector3(0, 0, -10);
			}
			else
			{
				float x = Input.GetAxisRaw("Horizontal") * targetZoom / speedMoveDivider;
				float y = Input.GetAxisRaw("Vertical") * targetZoom / speedMoveDivider;
				targetCam.position += new Vector3(x, y, 0);
			}
			if (Input.mousePosition.x <= 15)
			{
				targetCam.position -= new Vector3(targetZoom / speedMoveDivider, 0, 0);
			}
			else
			{
				if (Input.mousePosition.x >= Screen.width - 15)
				{
					targetCam.position += new Vector3(targetZoom / speedMoveDivider, 0, 0);
				}
			}
			if (Input.mousePosition.y >= Screen.height - 15)
			{
				targetCam.position += new Vector3(0, targetZoom / speedMoveDivider, 0);
			}
			else
			{
				if (Input.mousePosition.y <= 15)
				{
					targetCam.position -= new Vector3(0, targetZoom / speedMoveDivider, 0);
				}
			}
			float w2 = terreno.GetComponent<LevelGenerator>().Map.width / 2;
			float h2 = terreno.GetComponent<LevelGenerator>().Map.height / 2;
			float xC = Mathf.Clamp(targetCam.position.x, -w2, w2);
			float yC = Mathf.Clamp(targetCam.position.y, -h2, h2);

			targetCam.position = new Vector3(xC, yC, -10);
			Vector3 targetCamPos = target.position + targetCam.position;
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
