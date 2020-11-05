using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


namespace GeekGame.Input{
	public class JoystickRotate : JoystickMove
	{

		public static JoystickRotate rinstance = null;


		void Awake(){

			if(rinstance != null){
				Destroy(this.gameObject);
			}else{
				rinstance = this;
			}
		}

	}
}