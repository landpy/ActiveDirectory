param($installPath, $toolsPath, $package, $project)
$solution = Get-Interface $dte.Solution ([EnvDTE80.Solution2])
foreach ($project in $solution.Projects) { if($project.Name -eq "Schema"){$schemaProject = $project} }
if($schemaProject -eq $null){$schemaProject = $solution.AddSolutionFolder("Schema")}
$projectItems = Get-Interface $schemaProject.ProjectItems ([EnvDTE.ProjectItems])
$sourceXsdFilePath = $toolsPath+"\TestFrameWork.xsd"
$schemaDirectoryPath = $solution.FullName.Substring(0, $solution.FullName.LastIndexOf('\')) +"\Schema"
$destXsdFilePath = $schemaDirectoryPath+"\TestFrameWork.xsd"
if (!(Test-Path -path $schemaDirectoryPath)) {New-Item $schemaDirectoryPath -Type Directory}
Copy-item $sourceXsdFilePath -destination $destXsdFilePath -recurse
$projectItems.AddFromFile($destXsdFilePath)