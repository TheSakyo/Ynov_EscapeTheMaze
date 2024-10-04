using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Enemies {

    /**
     * <summary>
     * Represents all the enemies character in the game, handling movement and interactions.
     * </summary>
     */
    public class EnemyController : MonoBehaviour {

        /***********************/
        /****** PROPERTIES *****/
        /**********************/

        [SerializeField]
        private Transform player; // Reference to the player GameObject

        [SerializeField]
        private float followDistance; // Distance within which the enemy's will follow the player

        [SerializeField]
        private float speed; // Speed at which the enemy's follows the player

        /***********************/

        private Vector3 _initialPosition; // Store the initial position of the enemies

        /*****************************/
        /****** START & UPDATING *****/
        /****************************/

        /**
         * <summary>
         * Method called before the first frame update.
         * Initializes the initial position of the GameObject.
         * </summary>
         */
        void Start() {

            // Store the initial position of the object
            _initialPosition = transform.position;
        }

        /**
          * <summary>
          * Method called once per frame.
          * It checks the distance between the enemy's and the player, and moves the enemy's if close enough.
          * </summary>
          */
        void Update() {

            // Calculate the distance between the enemy's and the player
            float distance = Vector3.Distance(transform.position, player.position);

            // If the player is within follow distance, move towards the player
            if(distance < followDistance) {

                Vector3 direction = (player.position - transform.position).normalized; // Calculate direction to the player
                transform.position += direction * speed * Time.deltaTime; // Move towards the player
            }
        }

        /******************************/
        /****** GETTERS & SETTERS *****/
        /******************************/

        /**
         * <summary>
         * Gets or sets the player GameObject.
         * </summary>
         */
        public Transform Player { get => player; set => player = value; }

        /**
         * <summary>
         * Gets or sets the distance within which the enemy's will follow the player.
         * </summary>
         */
        public float FollowDistance { get => followDistance; set => followDistance = value; }

        /**
         * <summary>
         * Gets or sets the speed at which the enemy's follow the player.
         * </summary>
         */
        public float Speed { get => speed; set => speed = value; }

        /**
         * <summary>
         * Gets the initial position of the enemy's.
         * </summary>
         */
        public Vector3 InitialPosition { get => _initialPosition; }

        /*****************************/
        /****** EVENTS FUNCTIONS *****/
        /****************************/

        /**
         * OnTriggerEnter Event method called when another collider enters the trigger collider attached to this GameObject.
         * It resets the enemy's position when the player collides with it.
         * <param name="other">The collider that entered the trigger</param>
         */
        private void OnTriggerEnter2D(Collider2D other) {

            /*
             * Check if the object collides with the player,
             * then reset all character's position's and load GameOver scene
             */
            if(other.CompareTag("Player")) {

                // Reset all character's position's
                ActionUtilities.ResetCharacters(player);

                // Load the GameOver scene
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
