using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers {

    /**
     * <summary>
     * Manages the Game Over screen logic, allowing the player to restart the game.
     * </summary>
     */
    public class GameOverManager : MonoBehaviour {

        /***********************/
        /****** PROPERTIES *****/
        /**********************/

        // Reference to the button that allows the player to restart the game
        public Button restartButton;

        /*****************************/
        /****** START & UPDATING *****/
        /****************************/

        /**
         * <summary>
         * Method called before the first frame update.
         * Initializes button listener for restarting the game.
         * </summary>
         */
        private void Start() {

            // Add a listener to the restart button, triggering RestartGame method when clicked
            restartButton.onClick.AddListener(RestartGame);
        }

        /**
         * <summary>
         * Method called once per frame (currently empty).
         * Can be used to update any elements of the object during execution.
         * </summary>
         */
        public void Update() {}

        /******************************/
        /****** GETTERS & SETTERS *****/
        /******************************/

        /**
          * <summary>
          * Gets or sets the restart button.
          * </summary>
          */
        public Button RestartButton { get => restartButton; set => restartButton = value; }

        /*******************************/
        /****** PRIVATES FUNCTIONS *****/
        /*******************************/

        /**
         * <summary>
         * Restarts the game by loading the main game scene.
         * </summary>
         */
        private void RestartGame() {

            // Load the main game scene
            SceneManager.LoadScene("Game");
        }
    }
}

