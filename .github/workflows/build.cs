# The name of the workflow as it appears in the GitHub Actions tab
name: VaultBreaker Production Build

# TRIGGER: This defines when the robot wakes up to start working
on:
  push:
    # This tells it to only run when you push code to the 'main' branch
    branches: [ main ]

# JOBS: The actual work to be performed
jobs:
  build_job:
    # We use windows-latest because C# and 'win-x64' publishing 
    # run most reliably on Windows virtual machines.
    runs-on: windows-latest

    steps:
    # STEP 1: Pull your code from the GitHub repo into the virtual machine
    - name: Checkout Source Code
      uses: actions/checkout@v4

    # STEP 2: Install the .NET SDK so the machine understands 'dotnet' commands
    - name: Setup .NET SDK
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: '8.0.x' # Uses the latest version of .NET 8

    # STEP 3: The "Magic" Command
    # -c Release: Optimizes the code (removes debug info, makes it faster)
    # -r win-x64: Targets 64-bit Windows specifically
    # --self-contained true: Includes the .NET engine so others don't need it installed
    # -p:PublishSingleFile=true: Squashes everything into one .exe file
    # -o ./publish: Places the final result in a folder named 'publish'
    - name: Create Self-Contained Executable
      run: dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o ./publish

    # STEP 4: Save the result so you can download it from the browser
    - name: Save Build Artifacts
      uses: actions/upload-artifact@v4
      with:
        name: VaultBreaker-Win64-App # The name of the ZIP file you'll download
        path: ./publish # The folder we want to zip up
        retention-days: 7 # GitHub will delete this after 7 days to save space