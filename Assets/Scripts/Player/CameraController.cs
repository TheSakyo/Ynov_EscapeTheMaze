using UnityEngine;

namespace Player {

    /**
     * <summary>
     * Controls the camera behavior, specifically following the player character
     * at a specified speed.
     * </summary>
     */
    public class CameraController : MonoBehaviour {

        /***********************/
        /****** PROPERTIES *****/
        /**********************/

        [SerializeField]
        private GameObject player; // Reference to the player GameObject

        /*****************************/
        /****** START & UPDATING *****/
        /****************************/

        /**
          * <summary>
          * Method called once per frame (currently empty).
          * Initializes the camera settings or components necessary for camera behavior in the game.
          * </summary>
          */
        void Start() {}

        /**
          * <summary>
          * Method called once per frame.
          * Can be used to update any elements of the object during execution.
          * </summary>
          */
        private void Update() { FollowPlayer(); }

        /*******************************/
        /****** PRIVATES FUNCTIONS *****/
        /*******************************/

        /**
         * <summary>
         * Makes the camera follow the player's position.
         * </summary>
         */
        private void FollowPlayer() {

            Vector3 targetPosition = player.transform.position; // Get the player's current position
            targetPosition.z = -10f; // Adjust for desired distance

            transform.position = new Vector3(targetPosition.x, targetPosition.y, targetPosition.y); // Set the camera's position to the target position
        }
    }
}

