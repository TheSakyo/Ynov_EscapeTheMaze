using System.Collections.Generic;
using UnityEngine;

/*
 * This namespace represents the script's parent folder.
 */
namespace Maps {

    //! *** THIS SCRIPT IS NOT IMPLEMENTED *** //
    //! *** IT IS NOT NECESSARY TO BE VISIBLE *** //

    /**
     * <summary>
     * Generates a maze using a procedural algorithm. The maze is represented as a grid of cells,
     * where walls are instantiated based on the generated maze structure.
     * </summary>
     */
    public class MazeGenerator : MonoBehaviour  {

        /***********************/
        /****** PROPERTIES *****/
        /**********************/

        // The prefab used for the maze walls
        [SerializeField]
        private GameObject wallPrefab;

        // The width of the maze (number of cells)
        [SerializeField]
        private int width;

        // The height of the maze (number of cells)
        [SerializeField]
        private int height;

        /**********************/

        // 2D array representing the maze structure
        private Cell[,] _maze;

        /*****************************/
        /****** START & UPDATING *****/
        /****************************/

        /**
         * <summary>
         * Method called before the first frame update.
         * Calls the maze generation function.
         * </summary>
         */
        public void Start() { GenerateMaze(); }

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
         * Gets or sets the wall prefabs.
         * </summary>
         */
        public GameObject WallPrefab { get => wallPrefab; set => wallPrefab = value; }

        /**
         * <summary>
         * Get or sets the width of the maze.
         * </summary>
         */
        public int Width { get => width; set => width = value;}

        /**
         * <summary>
         * Get or sets the height of the maze.
         * </summary>
         */
        public int Height { get => height; set => height = value; }

        /*******************************/
        /****** PRIVATES FUNCTIONS *****/
        /*******************************/

        /**
         * <summary>
         * Generates the maze by initializing a 2D array of Cell objects
         * and instantiating wall prefabs at each cell position.
         * It also starts the process of generating paths from the
         * top-left corner of the maze.
         * </summary>
         */
        private void GenerateMaze() {

           // Initialize the 2D array for the maze with the specified width and height
           _maze = new Cell[width, height];

           // Loop through the width of the maze to create each column
           for(int x = 0; x < width; x++) {

             // Loop through the height of the maze to create each row
              for(int y = 0; y < height; y++) {

                 // Instantiate a new Cell object at the current (x, y) position
                 _maze[x, y] = new Cell();

                 // Create a new Vector2 position for the wall at the current (x, y) coordinates
                 Vector2 position = new Vector2(x, y);

                 // Instantiate a wall prefab at the calculated position with the default rotation
                 Instantiate(wallPrefab, position, Quaternion.identity);
              }
           }

           // Start generating paths in the maze from the top-left corner (0, 0)
           GeneratePaths(0, 0);
        }

        /**
         * <summary>
         * Generates the paths of maze using a backtracking algorithm starting from the specified cell.
         * </summary>
         * <param name="x">The x-coordinate of the starting cell.</param>
         * <param name="y">The y-coordinate of the starting cell.</param>
         */
        private void GeneratePaths(int x, int y) {

            /*
             * List of possible directions (up, down, left, right)
             */
            List<Vector2Int> directions = new List<Vector2Int> {

             new Vector2Int(1, 0),  // right
             new Vector2Int(-1, 0), // left
             new Vector2Int(0, 1),  // up
             new Vector2Int(0, -1)  // down
            };


            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };


            /*
             * Randomly shuffle the directions to create a random maze
             */
            for(int i = 0; i < directions.Count; i++) {

             Vector2Int temp = directions[i];
             int randomIndex = Random.Range(i, directions.Count);
             directions[i] = directions[randomIndex];
             directions[randomIndex] = temp;
            }

            /*
             * Explore each direction
             */
            foreach(Vector2Int direction in directions) {

                int newX = x + direction.x;
                int newY = y + direction.y;

                // If the new cell is within the maze bounds and has not been visited
                if(IsInBounds(newX, newY) && !_maze[newX, newY].IsVisited) {

                    // Mark the new cell as visited
                    _maze[newX, newY].IsVisited = true;

                    // Recursively generate the paths from the new cell
                    GeneratePaths(newX, newY);
                }
            }
        }

        /************************************/

        /**
         * <summary>
         * Checks if the given cell is within the bounds of the maze.
         * </summary>
         * <param name="x">The x-coordinate of the cell to check.</param>
         * <param name="y">The y-coordinate of the cell to check.</param>
         * <returns><c>true</c> if the cell is within bounds; otherwise, <c>false</c>.</returns>
         */
        private bool IsInBounds(int x, int y) { return x >= 0 && x < width && y >= 0 && y < height; }
    }
}
