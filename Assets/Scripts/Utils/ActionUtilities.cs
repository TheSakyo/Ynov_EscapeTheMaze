using Enemies;
using Player;
using UnityEngine;

namespace Utils
{
    /**
     * <summary>
     * Provides utility methods for actions in the game, particularly focusing on resetting
     * Non-Player Characters (NPCs) and the player character to their initial positions.
     * This abstract class serves as a static container for action-related utility functions
     * that can be used throughout the game without needing to instantiate an object.
     * </summary>
     */
    public abstract class ActionUtilities {

        /**
         * <summary>
         * Resets the positions of all NPCs (Non-Player Characters) in the game back to their initial positions.
         * This includes resetting the player's position if a player transform is provided.
         * </summary>
         *
         * <param name="player">The Transform of the player character. If provided, the player's position will also be reset.</param>
         */
        public static void ResetCharacters(Transform player) {

            // Find all enemies game objects with their specified tags
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Iterate through each enemy's game object
            foreach(GameObject enemy in enemies) {

                // Try to get the specific script attached to the current enemy
                EnemyController enemyController = enemy.GetComponent<EnemyController>();

                /*
                 * Reset the current enemy position to its initial position if is controller is not null
                 */
                if(enemyController != null) {

                    enemyController.transform.position = enemyController.InitialPosition;
                }
            }

            /**********************************/

            /*
             * Get the script object of PlayerCharacter if target player exist, and reset the position to its initial position
             */
            if(player) {

                PlayerCharacter playerCharacter = player.gameObject.GetComponent<PlayerCharacter>();
                playerCharacter.transform.position = playerCharacter.InitialPosition;
            }
        }
    }
}