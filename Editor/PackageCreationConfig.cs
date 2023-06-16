namespace PackagesCreator
{
    public class PackageCreationConfig
    {
        public bool CreateTests = true;
        public bool CreateEditor = true;
        public bool CreateDefaultScript = false;
        public bool CreateGitRepo = true;

        public string PackageName = "MyCoolPackage";
        public string PackageDescription = "";
        public string PackageAuthor = "Marcos Alvarez";
        public string PackageAuthorEmail = "alvmivan@gmail.com";
        public string Organization = "orbitar";
    }
}