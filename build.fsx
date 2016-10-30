// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open System
open System.IO
open Fake
open Fake.NpmHelper
open System.Diagnostics

module Fake = 
    let fakePath = "packages" </> "docs" </> "FAKE" </> "tools" </> "FAKE.exe"
    let fakeStartInfo script workingDirectory args fsiargs environmentVars =
        (fun (info: System.Diagnostics.ProcessStartInfo) ->
            info.FileName <- System.IO.Path.GetFullPath fakePath
            info.Arguments <- sprintf "%s --fsiargs -d:FAKE %s \"%s\"" args fsiargs script
            info.WorkingDirectory <- workingDirectory
            let setVar k v = info.EnvironmentVariables.[k] <- v
            for (k, v) in environmentVars do setVar k v
            setVar "MSBuild" msBuildExe
            setVar "GIT" Git.CommandHelper.gitPath
            setVar "FSI" fsiPath)

    /// Run the given buildscript with FAKE.exe
    let executeFAKEWithOutput workingDirectory script fsiargs envArgs =
        let exitCode =
            ExecProcessWithLambdas
                (fakeStartInfo script workingDirectory "" fsiargs envArgs)
                TimeSpan.MaxValue false ignore ignore
        System.Threading.Thread.Sleep 1000
        exitCode

// Directories
let buildDir  = "./build/"
let deployDir = "./deploy/"


// Filesets
let appReferences  =
    !! "./src/**/*.csproj"
      ++ "./src/**/*.fsproj"

// version info
let version = "0.1"  // or retrieve from CI server


// this should not be needed (https://github.com/fsharp/FAKE/blob/73589a85a5e30a2c78d61efccdd3446a99483142/src/app/FakeLib/NpmHelper.fs), but as of 2016-10-30 I need it
let isWindows = Environment.OSVersion.Platform = PlatformID.Win32NT
let private npmFileName =
    match isWindows with
    | true ->  
        let path = System.Environment.GetEnvironmentVariable("PATH")
        path
        |> fun path -> path.Split ';'
        |> Seq.tryFind (fun p -> p.Contains "nodejs")
        |> fun res ->
            match res with
            | Some npm when File.Exists (sprintf @"%s\npm.cmd" npm) -> (sprintf @"%s\npm.cmd" npm)
            | _ -> "./packages/Npm.js/tools/npm.cmd"
    | _ -> 
        let info = new ProcessStartInfo("which","npm")
        info.StandardOutputEncoding <- System.Text.Encoding.UTF8
        info.RedirectStandardOutput <- true
        info.UseShellExecute        <- false
        info.CreateNoWindow         <- true
        use proc = Process.Start info
        proc.WaitForExit()
        match proc.ExitCode with
            | 0 when not proc.StandardOutput.EndOfStream ->
              proc.StandardOutput.ReadLine()
            | _ -> "/usr/bin/npm"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; deployDir]
)

Target "Npm" (fun _ ->
    Npm (fun p ->
            { p with
                NpmFilePath = npmFileName
                Command = Install Standard
                WorkingDirectory = "./src/Fable.Import.SharePoint/"
            })
)

Target "Build" (fun _ ->
    // compile all projects below src/app/
    MSBuildDebug buildDir "Build" appReferences
        |> Log "AppBuild-Output: "
)

Target "Deploy" (fun _ ->
    !! (buildDir + "/**/*.*")
        -- "*.zip"
        |> Zip buildDir (deployDir + "ApplicationName." + version + ".zip")
)

Target "BrowseDocs" (fun _ ->
    let exit = Fake.executeFAKEWithOutput "docs" "docs.fsx" "" ["target", "BrowseDocs"]
    if exit <> 0 then failwith "Browsing documentation failed"
)

Target "GenerateDocs" (fun _ ->
    let exit = Fake.executeFAKEWithOutput "docs" "docs.fsx" "" ["target", "GenerateDocs"]
    if exit <> 0 then failwith "Generating documentation failed"
)

Target "PublishDocs" (fun _ ->
    let exit = Fake.executeFAKEWithOutput "docs" "docs.fsx" "" ["target", "PublishDocs"]
    if exit <> 0 then failwith "Publishing documentation failed"
)

// Build order
"Clean"
  ==> "Npm"
  ==> "Build"
  ==> "Deploy"

// start build
RunTargetOrDefault "Build"
