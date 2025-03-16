namespace MagicVilla_VillaAPI
{
    public static class AppConstants
    {
        public static readonly string repeatedName = "repeatedname";
        public static readonly string repeatedVillaNumber = "repeatedVillaNumber";
        public static readonly string villaDoesNotExist = "villaDoesNotExist";

        #region Messages for Status Controller
        public static readonly string WelcomeMessage = "Welcome to Villa API";
        #endregion
        public static readonly string SuccessMessage = "Operation was successful";
        #region Messages for Villa Controller
        public static readonly string VillaNotFound = "Villa with Id: {0} does not exist";
        public static readonly string EnterValidID = "Please enter a valid Id";
        public static readonly string RepeatedNames = "Villa name already exists";
        public static readonly string InvalidData = "Invalid data or ID mismatch.";
        #endregion

        #region Messages for VillaNumber Controller
        public static readonly string VillaNumberNotFound = "VillaNumber: {0} does not exist";
        public static readonly string EnterValidVillaNumber = "Please enter a valid villaNumber";
        public static readonly string RepeatedVillaNumber = "Villa Number already exists";
        public static readonly string InvalidVNData = "Invalid data or Villa Number mismatch.";

        #endregion
    }
}
