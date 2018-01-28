#tool nuget:?package=Wyam
#addin "Cake.Wyam"
#addin "Cake.Npm"


//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Build")
    .Does(() =>
    {
        Wyam(new WyamSettings {
        Recipe = "Blog",
        Theme = "SolidState",
        UpdatePackages = true
        });        
    });
    
Task("Preview")
    .Does(() =>
        {
            Wyam(new WyamSettings {
            Recipe = "Blog",
            Theme = "SolidState",
            UpdatePackages = true,
            Preview = true,
            Watch = true
            });        
        });
        
Task("Deploy")
    .Does(() =>
    {
        // Add NETLIFY_TOKEN to your enviornment variables
        string token = EnvironmentVariable("NETLIFY_TOKEN");
        if(string.IsNullOrEmpty(token))
        {
            throw new Exception("Could not get NETLIFY_TOKEN environment variable");
        }

        // zip the output directory and upload using curl
        Zip("./output", "output.zip", "./output/**/*");
        StartProcess("curl", 
            "--header \"Content-Type: application/zip\" "
            + "--header \"Authorization: Bearer " + token + "\" "
            + "--data-binary \"@output.zip\" "
            + "--url https://api.netlify.com/api/v1/sites/eager-fermat-e7947e.netlify.com/deploys");
    });

    
//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Preview");    
    
//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);