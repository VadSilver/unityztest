using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;
using GeekGame.Input;
namespace CompleteProject
{
    public class PlayerMovementMobile : MonoBehaviour
    {
        public float speed = 6f;            // The speed that the player will move at.
        Vector3 movement;                   // The vector to store the direction of the player's movement.
        Animator anim;                      // Reference to the animator component.
        Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
        public Transform pCamera;
        public bool ifTopView = true;
        float xRotation = 0f;


        void Awake ()
        {
            // Set up references.
            anim = GetComponent <Animator> ();
            playerRigidbody = GetComponent <Rigidbody> ();
        }


        void Update ()
        {
			//the input axes from joystickMove
			float h=JoystickMove.minstance.H;
			float v=JoystickMove.minstance.V;

            if (ifTopView)
            {
                // Move the player around the scene.
                Move(h, v);

                // Turn the player to face the mouse cursor.
                Turning();
                TurningShootTop();
                
            }
            else { //ifFpsView

                MoveFps(h, v);
                TurningFps();
                TurningShootFps();
            }
            

            // Animate the player.
            Animating (h, v);
        }


        void MoveFps(float h, float v)
        {
            float x = h/20f;
            float z = v/20f;

            Vector3 move2 = transform.right * x + transform.forward * z;
            playerRigidbody.MovePosition(transform.position + move2 * Time.deltaTime);
            
        }

        void TurningFps()
        {

            float mouseX = JoystickRotate.rinstance.H * 1.5f * Time.deltaTime;
            float mouseY = JoystickRotate.rinstance.V * 1.0f * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -5f, 5f);

            pCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);


        }
        //rotShoot
        void TurningShootFps()
        {

            float mouseX = JoystickRotateShoot.rsinstance.H * 1.0f * Time.deltaTime;
            float mouseY = JoystickRotateShoot.rsinstance.V * 1.0f * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -5f, 5f);

            pCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        void TurningShootTop()
        {

            float mouseX = JoystickRotateShoot.rsinstance.H * 1.0f * Time.deltaTime;
            transform.Rotate(Vector3.up * mouseX);
        }


        void Move (float h, float v)
        {
            float x = h / 20f;
            float z = v / 20f;

            Vector3 move2 = transform.right * x + transform.forward * z;
            playerRigidbody.MovePosition(transform.position + move2 * Time.deltaTime);
        }


        void Turning ()
        {

            float mouseX = JoystickRotate.rinstance.H * 1.5f * Time.deltaTime;
            float mouseY = JoystickRotate.rinstance.V * 1.5f * Time.deltaTime;
            transform.Rotate(Vector3.up * mouseX);
        }


       
        void Animating (float h, float v)
        {
            // Create a boolean that is true if either of the input axes is non-zero.
            bool walking = h != 0f || v != 0f;

            // Tell the animator whether or not the player is walking.
            anim.SetBool ("IsWalking", walking);
        }
    }
}