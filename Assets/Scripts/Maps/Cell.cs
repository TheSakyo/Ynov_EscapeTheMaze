namespace Maps {

    //! *** THIS SCRIPT IS NOT IMPLEMENTED *** //
    //! *** IT IS NOT NECESSARY TO BE VISIBLE *** //

    /**
     * <summary>
     * Represents a cell within a maze map.
     * </summary>
     */
    public class Cell {

        /***********************/
        /****** PROPERTIES ****/
        /**********************/

        private bool _visited; // Store the visited state of the cell.

        /*******************************/
        /****** GETTERS & SETTERS *****/
        /******************************/

        /**
         * <summary>
         * Gets or sets the visited state of the cell.
         * </summary>
         */
        public bool Visited { get => _visited; set => _visited = value; }
    }
}
