using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


namespace GeekGame.Input{
	public class JoystickRotateShoot : JoystickMove
	{

		public static JoystickRotateShoot rsinstance = null;



		void Awake(){

			if(rsinstance != null){
				Destroy(this.gameObject);
			}else{
				rsinstance = this;
			}

		}



	}
}