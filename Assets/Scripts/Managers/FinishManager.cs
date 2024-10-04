using UnityEngine;
using UnityEngine.UI;

namespace Managers {

    /**
     * <summary>
     * Manages the Finish screen logic, allowing the player to quit the game.
     * </summary>
     */
    public class FinishManager : MonoBehaviour {

        /***********************/
        /****** PROPERTIES *****/
        /**********************/

        [SerializeField]
        private Button quitGameButton; // Reference to the main menu button

        /*****************************/
        /****** START & UPDATING *****/
        /****************************/

        /**
         * <summary>
         * Method called before the first frame update.
         * Initializes button listener for returning to quit the game.
         * </summary>
         */
        private void Start()
        {
            // Add a listener to the quit game button
            quitGameButton.onClick.AddListener(QuitGame);
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
          * Gets or sets the quit game button.
          * </summary>
          */
        public Button QuitGameButton { get => quitGameButton; set => quitGameButton = value; }

        /*******************************/
        /****** PRIVATES FUNCTIONS *****/
        /******************************/

        /**
         * <summary>
         * Quit the game, close the application.
         * </summary>
         */
        private void QuitGame() {

            #if UNITY_STANDALONE
                Application.Quit();
            #endif

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}

