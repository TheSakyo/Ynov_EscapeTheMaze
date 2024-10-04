using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Friends {

    /**
     * <summary>
     * Represents logic of all friends character (there is currently only one) in the game, handling interactions.
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
         * It resets friend's position when the player collides with it.
         * <param name="other">The collider that entered the trigger</param>
         */
        private void OnTriggerEnter2D(Collider2D other) {

            /*
             * Check if the object collides with the player,
             * then reset all character's positions and load finish scene
             */
            if(other.CompareTag("Player")) {

                // Reset all character's positions
                ActionUtilities.ResetCharacters(null);

                // Load the Finish scene
                SceneManager.LoadScene("Finish");
            }
        }
    }
}
