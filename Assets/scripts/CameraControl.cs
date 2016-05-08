using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float CameraSpeed = 100.0f;
	public float CameraSpeedBoostMultiplier = 2.0f; 
	
	public float DefaultCameraPosX = 8.6f;
	public float DefaultCameraPosY = 34.2f;
	public float DefaultCameraPosZ = 8.6f;
	
	private void Awake()
	{
		//transform.position = new Vector3(DefaultCameraPosX, DefaultCameraPosY, DefaultCameraPosZ);
	}
	
	private void Update()
	{
		float smoothCamSpeed = CameraSpeed * Time.smoothDeltaTime; 
		
		if (Input.GetKey(KeyCode.W)) transform.position += Input.GetKey(KeyCode.LeftShift) ? new Vector3(0.0f, 0.0f, smoothCamSpeed * CameraSpeedBoostMultiplier) : new Vector3(0.0f, 0.0f, smoothCamSpeed); //вверх
		if (Input.GetKey(KeyCode.A)) transform.position += Input.GetKey(KeyCode.LeftShift) ? new Vector3(-smoothCamSpeed * CameraSpeedBoostMultiplier, 0.0f, 0.0f) : new Vector3(-smoothCamSpeed, 0.0f, 0.0f); //налево
		if (Input.GetKey(KeyCode.S)) transform.position += Input.GetKey(KeyCode.LeftShift) ? new Vector3(0.0f, 0.0f, -smoothCamSpeed * CameraSpeedBoostMultiplier) : new Vector3(0.0f, 0.0f, -smoothCamSpeed); //вниз
		if (Input.GetKey(KeyCode.D)) transform.position += Input.GetKey(KeyCode.LeftShift) ? new Vector3(smoothCamSpeed * CameraSpeedBoostMultiplier, 0.0f, 0.0f) : new Vector3(smoothCamSpeed, 0.0f, 0.0f); //направо
	}
}


