#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Testing.NUnit3

let buildDir = "./bin/Debug/"

let solutionFile = "./exercism.fsproj"
let compiledOutput = buildDir @@ "exercism.dll"

Target "Clean" (fun _ ->
  CleanDirs [buildDir]
)

Target "Build" (fun _ ->
  MSBuildRelease buildDir "Build" [solutionFile]
  |> Log "Build:"
)

Target "Test" (fun _ ->
  [compiledOutput]
  |> NUnit3 (fun p -> { p with ShadowCopy = false })
)

"Clean"
  ==> "Build"
  ==> "Test"

RunTargetOrDefault "Test"
