using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public int waveAmount = 5; 
	public int waveNumber = 0; 
	public float waveDelayTimer = 30.0F;
	public float waveCooldown = 20.0F;
	public int maximumWaves = 5; 
	public Transform Mob; 

	private void Update()
	{
		if (waveDelayTimer > 0) 
		{

				if (GlobalVars.MobCount == 0) waveDelayTimer = 0;
				else waveDelayTimer -= Time.deltaTime;

		}
		if (waveDelayTimer <= 0)
		{
			if (waveNumber < maximumWaves)
			{
					for (int i = 0; i < waveAmount; i++) 
					{
					Instantiate(Mob, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
					}
					
					if (waveCooldown > 5.0f) 
					{
						waveCooldown -= 0.1f; 
						waveDelayTimer = waveCooldown; 
					}
					else
					{
						waveCooldown = 5.0f;
						waveDelayTimer = waveCooldown;
					}
					
					if (waveNumber >= 50)
					{
						waveAmount = 10; 
					}
				waveNumber++; 
			}
		}
	}
}
