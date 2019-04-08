# Scraper Demo

## Dependencies
- .NET Core 2.1
- ASP.NET Core 2.1.1

- Node.JS 10.4.2
- Npm 6.4.2

# Getting Started
Ensure Gulp-Cli is installed:
`npm install --global gulp-cli`

1. Open solution file in Visual Studio 2017:
	- If your VS environment has `NPM: Restore On Project Open` set to `True`:
		- Wait for npm install to complete (view Output window for Bower/npm), go to step 2
	- If your VS environment has `NPM: Restore On Project Open` set to `False`:
		- Open a command prompt window to the solution directory
		- Run command `npm ci`, this should install all correct packages, go to step 2

2. Rebuild solution
	- Build -> Rebuild Solution

3. Run via IIS Express
	- Debug -> Start Debugging
	

# Debugging API
1. Download Advanced Rest Client (ARC) at https://install.advancedrestclient.com/install 
2. Open the project file located in the solution (`scraperdemo.json`)
3. Import Data
4. Navigate to the demo api call, and hit `Send`
5. Hostname can be configured by adjusting the `${BaseUrl}` variable (see top right for `Environment` setting)
6. Request body can be adjusted to set a new URL for testing.