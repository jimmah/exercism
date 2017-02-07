#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Testing.NUnit3

let buildDir = "./build"
let sourceDir = "./"

let projectFile = buildDir @@ "/exercism.csproj"
let compiledOutput = buildDir @@ "exercism.dll"
let nunitToJunitTransformFile = "./paket-files" @@ "nunit" @@ "nunit-transforms" @@ "nunit3-junit" @@ "nunit3-junit.xslt"

Target "PrepareUnchanged" (fun  _ ->
    CleanDirs [buildDir]
    CopyDir buildDir sourceDir allFiles
)

Target "BuildUnchanged" (fun _ ->
    MSBuildRelease buildDir "Build" [projectFile]
    |> Log "Build unchanged output: "
)

Target "PrepareTests" (fun _ ->
    CleanDirs [buildDir]
    CopyDir buildDir sourceDir allFiles

    let ignorePattern = "(\[Ignore\(\"Remove to run test\"\)]|, Ignore = \"Remove to run test case\")"

    !! (buildDir @@ "**/*Test.cs")
    |> RegexReplaceInFilesWithEncoding ignorePattern "" System.Text.Encoding.UTF8
)

Target "BuildTests" (fun _ ->
    MSBuildRelease buildDir "Build" [projectFile]
    |> Log "Build tests output: "
)

Target "Test" (fun _ ->
    [compiledOutput]
    |> NUnit3 (fun p -> { p with ShadowCopy = false })
)

"PrepareUnchanged"
  ==> "BuildUnchanged"
  ==> "PrepareTests"
  ==> "BuildTests"    
  ==> "Test"

RunTargetOrDefault "Test"