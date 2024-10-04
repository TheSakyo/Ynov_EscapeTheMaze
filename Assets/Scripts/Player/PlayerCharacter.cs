using System;
using UnityEngine;

namespace Player {

    /**
     * <summary>
     * Represents the player character in the game, handling movement and interactions.
     * </summary>
     */
    public class PlayerCharacter : MonoBehaviour {

        /***********************/
        /****** PROPERTIES *****/
        /**********************/

        // The speed at which the player character moves
        [SerializeField]
        private float speed;

        // The smoothing factor for the player's movement. Higher values result in smoother transitions
        [SerializeField]
        private float smoothing;

        // The initial position of the player
        private Vector3 _initialPosition;

        /***************************/

        private Vector2 _targetPosition; // The target position the player is moving towards
        private Vector2 _velocity = Vector2.zero; // Used for smooth movement transitions
        private Vector2 _movementDirection = Vector2.zero; // Direction of movement

        /***************************/

        private Rigidbody2D _rigideBody; // Reference to the Rigidbody2D component for physics-based movement

        /*****************************/
        /****** START & UPDATING *****/
        /****************************/

        /**
         * <summary>
         * Method called before the first frame update.
         * Initializes the Rigidbody2D component used for physics-based movement of the player character.
         * </summary>
         */
        public void Start() {

            // Get the reference to the Rigidbody2D component for physics-based movement
            _rigideBody = GetComponent<Rigidbody2D>();

            // Store the initial position of the object
            _initialPosition = transform.position;
        }

        /**
         * <summary>
         * Method called once per frame.
         * Can be used to update any elements of the object during execution.
         * </summary>
         */
        public void Update() {

            //MovePosition(); Obsolete Move Function
            Move(); // Update Player Move
        }

        /******************************/
        /****** GETTERS & SETTERS *****/
        /******************************/

        /**
         * <summary>
         * Gets or sets the speed of player.
         * </summary>
         */
        public float Speed { get => speed; set => speed = value; }

        /**
         * <summary>
         * Gets or sets the smoothing factor for player movement.
         * This property controls how smoothly the player transitions between movements.
         * </summary>
         */
        public float Smoothing { get => smoothing; set => smoothing = value; }

        /**
         * <summary>
         * Gets the initial position of the player.
         * </summary>
         */
        public Vector3 InitialPosition { get => _initialPosition; }

        /*******************************/
        /****** PRIVATES FUNCTIONS *****/
        /*******************************/

        /**
         * <summary>
         * Handles player movement based on input and applies movement to the Rigidbody or directly to the transform.
         * </summary>
         */
        private void Move() {

            // Get input from the horizontal and vertical axes
            _movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            // Calculate the target position based on current position, movement direction, speed, and time
            _targetPosition = transform.position + (Vector3)_movementDirection * speed * Time.deltaTime;

            /*
             * Apply movement to the Rigidbody if it exists, otherwise directly adjust the transform position
             */
            if(_rigideBody) _rigideBody.velocity = ((Vector3)_targetPosition - transform.position) / Time.fixedDeltaTime;
            else transform.position = Vector2.SmoothDamp(transform.position, _targetPosition, ref _velocity, smoothing);
        }

        /*********************************/
        /****** DEPRECATED FUNCTIONS *****/
        /*********************************/

        /**
         * <summary>
         * Handles player movement detection based on key inputs. This method is marked as obsolete because it relies on
         * the deprecated <c>MovePosition</c> function. Consider using an alternative movement method.
         * </summary>
         */
        [Obsolete("MoveDetection relies on the deprecated MovePosition function. Use an alternative movement method.")]
        private void MoveDetection() {

            // Get the key code from the input string
            KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());

            // Reset movement direction to zero at the start of every frame
            _movementDirection = Vector2.zero;

            /*
             * Update movement direction based on the pressed key
             */
            switch(keyCode) {
                case KeyCode.Z:
                case KeyCode.W:
                    _movementDirection = Vector2.up;
                    break;
                case KeyCode.S:
                    _movementDirection = Vector2.down;
                    break;
                case KeyCode.Q:
                case KeyCode.A:
                    _movementDirection = Vector2.left;
                    break;
                case KeyCode.D:
                    _movementDirection = Vector2.right;
                    break;
            }
        }

        /**
         * <summary>
         * Moves the player to a target position based on detected input. This function is marked as obsolete because
         * it causes jittery movement. Please use <c>Move()</c> instead.
         * </summary>
         */
        [Obsolete("This function works but causes jittery movement. Please use Move() instead.")]
        private void MovePosition() {

            MoveDetection(); // Detect movement direction based on key input

            // Calculate the target position based on the current position, movement direction, speed, and smoothing factor
            Vector3 position = transform.position + new Vector3(_movementDirection.x, _movementDirection.y, 0) * speed * smoothing;

            // Smoothly transition the player's position to the target position
            transform.position = Vector2.SmoothDamp(transform.position, new Vector2(position.x, position.y), ref _velocity, smoothing);
        }
    }
}

