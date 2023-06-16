namespace PackagesCreator
{
    public class PackageConfigValidator
    {
        public static bool ValidatePackageName(string packageName, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(packageName))
            {
                errorMessage = "Package name cannot be empty or whitespace.";
                return false;
            }

            if (packageName.Contains(" "))
            {
                errorMessage = "Package name cannot contain spaces.";
                return false;
            }

            return true;
        }

        public static bool ValidatePackageDescription(string packageDescription, out string errorMessage)
        {
            // No specific validation rules for package description
            errorMessage = null;
            return true;
        }

        public static bool ValidatePackageAuthor(string packageAuthor, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(packageAuthor))
            {
                errorMessage = "Package author cannot be empty or whitespace.";
                return false;
            }

            errorMessage = null;
            return true;
        }

        public static bool ValidatePackageAuthorEmail(string packageAuthorEmail, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(packageAuthorEmail))
            {
                errorMessage = "Package author email cannot be empty or whitespace.";
                return false;
            }

            // You can add additional email validation logic here if needed

            errorMessage = null;
            return true;
        }

        public static bool ValidateOrganization(string organization, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(organization))
            {
                errorMessage = "Organization cannot be empty or whitespace.";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}