using UnityEngine;
using System.Collections;

public class ShipParticles : MonoBehaviour {
	
	public float upperIntensity;
	public float lowerIntensity;
	
	public Light flickeringLight;
	public ParticleSystem exhastParticles;
	public ParticleSystem turnParticlesLeft;
	public ParticleSystem turnParticlesRight;
	
	void FixedUpdate() {
		if(Input.GetAxis("Horizontal") < 0){
			turnParticlesLeft.GetComponent<ParticleSystem>().Emit(1);
		}
		else if(Input.GetAxis("Horizontal") > 0){ //Maybe use GetAxisRaw to get it to input 1 or -1
			turnParticlesRight.GetComponent<ParticleSystem>().Emit(1);
		}
		
		//if(Input.GetButton("Thrust" + playerNumber)){
			flickeringLight.intensity = Random.Range(lowerIntensity, upperIntensity);
			//exhastParticles.particleSystem.Play();
		//}
		//else{
			flickeringLight.GetComponent<Light>().intensity = 0;
			exhastParticles.GetComponent<ParticleSystem>().Play();
		//}
	}
}
