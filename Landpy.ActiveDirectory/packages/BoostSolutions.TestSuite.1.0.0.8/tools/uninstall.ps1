param($installPath, $toolsPath, $package, $project)
$solution = Get-Interface $dte.Solution ([EnvDTE80.Solution2])
$schemaDirectoryPath = $solution.FullName.Substring(0, $solution.FullName.LastIndexOf('\')) +"\Schema"
foreach ($project in $solution.Projects) { if($project.Name -eq "Schema"){$schemaProject = $project} }
Remove-Item -Recurse -Force $schemaDirectoryPath
$schemaProject.Delete()