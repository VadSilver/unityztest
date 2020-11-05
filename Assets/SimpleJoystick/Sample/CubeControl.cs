using UnityEngine;
using System.Collections;
using GeekGame.Input;

public class CubeControl : MonoBehaviour {

	public float speed=.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(JoystickMove.minstance.H,0f,JoystickMove.minstance.V)*speed*Time.deltaTime);


		transform.LookAt(transform.position+new Vector3(JoystickRotate.rinstance.H,0f,JoystickRotate.rinstance.V));

		if(JoystickFire.instance.Fire){
			Debug.Log("fire");
		}
	}
}
