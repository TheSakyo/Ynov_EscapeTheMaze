using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Friends {

    /**
     * <summary>
     * Represents all the enemies character in the game, handling movement and interactions.
     * </summary>
     */
    public class FriendLogic : MonoBehaviour {

        /***********************/
        /****** PROPERTIES *****/
        /**********************/

        [SerializeField]
        private Transform player; // Reference to the player GameObject

        /*****************************/
        /****** START & UPDATING *****/
        /****************************/

        /**
         * <summary>
         * Method called before the first frame update.
         * </summary>
         */
        void Start() {}

        /**
          * <summary>
          * Method called once per frame.
          * Can be used to update any elements of the object during execution.
          * </summary>
          */
        void Update() {}

        /******************************/
        /****** GETTERS & SETTERS *****/
        /******************************/

        /**
         * <summary>
         * Gets or sets the player GameObject.
         * </summary>
         */
        public Transform Player { get => player; set => player = value; }

        /*****************************/
        /****** EVENTS FUNCTIONS *****/
        /****************************/

        /**
         * OnTriggerEnter Event method called when another collider enters the trigger collider attached to this GameObject.
         * It resets the object's position when the player collides with it.
         * <param name="other">The collider that entered the trigger</param>
         */
        private void OnTriggerEnter2D(Collider2D other) {

            /*
             * Check if the object collides with the player,
             * then reset all character's position's and load finish scene
             */
            if(other.CompareTag("Player")) {

                // Reset all character's position's
                ActionUtilities.ResetCharacters(null);

                // Load the Finish scene
                SceneManager.LoadScene("Finish");
            }
        }
    }
}
