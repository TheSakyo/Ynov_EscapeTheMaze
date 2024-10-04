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
        /****** PROPERTIES *****/
        /**********************/

        private bool _isVisited; // Store the visited state of the cell

        /******************************/
        /****** GETTERS & SETTERS *****/
        /******************************/

        /**
         * <summary>
         * Gets or sets the visited state of the cell.
         * </summary>
         */
        public bool IsVisited { get => _isVisited; set => _isVisited = value; }
    }
}
