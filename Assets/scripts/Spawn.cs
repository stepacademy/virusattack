using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public int waveAmount; 
	public int waveNumber; 
	public float waveDelayTimer;
	public float waveCooldown;
	public int maximumWaves; 
	public Transform Mob; 

	private void Update()
	{
		if (GlobalVars.Basis != null) {
			if (waveDelayTimer > 0) {

				if (GlobalVars.MobCount == 0)
					waveDelayTimer = 0;
				else
					waveDelayTimer -= Time.deltaTime;

			}
			if (waveDelayTimer <= 0) {
				if (waveNumber < maximumWaves) {
					for (int i = 0; i < waveAmount; i++) {
						Instantiate (Mob, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
					}
					
					if (waveCooldown > 5.0f) {
						waveCooldown -= 0.1f; 
						waveDelayTimer = waveCooldown; 
					} else {
						waveCooldown = 5.0f;
						waveDelayTimer = waveCooldown;
					}
					
					if (waveNumber >= 50) {
						waveAmount = 10; 
					}
					waveNumber++; 
				}
			}
		}
	}
}
