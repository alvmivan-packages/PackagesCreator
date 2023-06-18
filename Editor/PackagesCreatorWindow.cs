using UnityEditor;
using UnityEngine;

namespace PackagesCreator
{
    public class PackagesCreatorWindow : EditorWindow
    {
        string PackageName
        {
            get => config.PackageName;
            set => config.PackageName = value;
        }

        readonly PackageCreationConfig config = new();


        [MenuItem("Packages/Creator")]
        public static void ShowWindow()
        {
            var window = GetWindow<PackagesCreatorWindow>(false, "Packages Creator");
            window.Show();
        }


        void OnGUI()
        {
            PackagesCreator.FolderToCreatePackages.DrawStringField();

            if (!PackagesCreator.ExistsFolderToCreatePackages())
            {
                if (GUILayout.Button("Create Packages Folder"))
                {
                    PackagesCreator.CreateFolderToCreatePackages();
                }

                return;
            }

            if (GUILayout.Button("Open Packages Folder"))
            {
                PackagesCreator.OpenFolderToCreatePackages();
            }


            WriteProperties();

            if (!IsValidated(config))
            {
                EditorGUILayout.HelpBox("Please correct all the errors on the fields", MessageType.Warning);
                return;
            }

            if (PackagesCreator.PackageExists(PackageName))
            {
                EditorGUILayout.HelpBox(
                    $"A package with the name {PackageName} already exists. Please choose a different name.",
                    MessageType.Warning);

                if (GUILayout.Button("Delete Package"))
                {
                    PackagesCreator.DeletePackage(PackageName);
                }

                return;
            }

            if (GUILayout.Button("Create Package"))
            {
                {
                    PackagesCreator.CreatePackage(new PackageCreationConfig
                    {
                        PackageName = PackageName,
                        // Provide other necessary properties here
                    });
                    Debug.Log($"Package {PackageName} created successfully!");
                }
            }
        }

        void WriteProperties()
        {
            GUILayout.Label("Create a new Unity package", EditorStyles.boldLabel);
            GUILayout.Space(2);
            PackageName = EditorGUILayout.TextField("Package Name", PackageName);
            config.CreateTests = EditorGUILayout.Toggle("Create Tests", config.CreateTests);
            config.CreateEditor = EditorGUILayout.Toggle("Create Editor", config.CreateEditor);
            config.CreateDefaultScript = EditorGUILayout.Toggle("Create Default Script", config.CreateDefaultScript);
            config.CreateGitRepo = EditorGUILayout.Toggle("Create Git Repo", config.CreateGitRepo);

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Package Name");
            if (!PackageConfigValidator.ValidatePackageName(config.PackageName, out string nameErrorMessage))
            {
                EditorGUILayout.HelpBox(nameErrorMessage, MessageType.Warning);
            }

            config.PackageName = EditorGUILayout.TextField(config.PackageName);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Package Description");
            if (!PackageConfigValidator.ValidatePackageDescription(config.PackageDescription,
                    out string descriptionErrorMessage))
            {
                EditorGUILayout.HelpBox(descriptionErrorMessage, MessageType.Warning);
            }

            config.PackageDescription = EditorGUILayout.TextField(config.PackageDescription);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Package Author");
            if (!PackageConfigValidator.ValidatePackageAuthor(config.PackageAuthor, out string authorErrorMessage))
            {
                EditorGUILayout.HelpBox(authorErrorMessage, MessageType.Warning);
            }

            config.PackageAuthor = EditorGUILayout.TextField(config.PackageAuthor);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Package Author Email");
            if (!PackageConfigValidator.ValidatePackageAuthorEmail(config.PackageAuthorEmail,
                    out string emailErrorMessage))
            {
                EditorGUILayout.HelpBox(emailErrorMessage, MessageType.Warning);
            }

            config.PackageAuthorEmail = EditorGUILayout.TextField(config.PackageAuthorEmail);
            EditorGUILayout.EndHorizontal();
        }

        public static bool IsValidated(PackageCreationConfig config)
        {
            bool isValid = true;
            string errorMessage = string.Empty;

            // Validate Package Name
            if (!PackageConfigValidator.ValidatePackageName(config.PackageName, out errorMessage))
            {
                isValid = false;
                Debug.LogWarning(errorMessage);
            }

            // Validate Package Description
            if (!PackageConfigValidator.ValidatePackageDescription(config.PackageDescription, out errorMessage))
            {
                isValid = false;
                Debug.LogWarning(errorMessage);
            }

            // Validate Package Author
            if (!PackageConfigValidator.ValidatePackageAuthor(config.PackageAuthor, out errorMessage))
            {
                isValid = false;
                Debug.LogWarning(errorMessage);
            }

            // Validate Package Author Email
            if (!PackageConfigValidator.ValidatePackageAuthorEmail(config.PackageAuthorEmail, out errorMessage))
            {
                isValid = false;
                Debug.LogWarning(errorMessage);
            }

            return isValid;
        }
    }
}