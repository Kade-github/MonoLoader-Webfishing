# MonoLoader-Webfishing
A C# Mono DLL Loader for Webfishing


## instructions to install

extract the build from [releases](https://github.com/Kade-github/MonoLoader-Webfishing/releases) into your webfishing folder.

Run PCKMerge and it should merge the to_merge.pck file into your webfishing.pck.

Run the game and it should create a "mono_mods" folder that you can place your mods into.

thats it.

## updates to the game

if the game updates that invalidates the pck file that we merged, so you'll have to rerun PCKMerge to get it to work again. thats if it ends up working, a ideal solution is to get an injector that does all of our mod loading but i'm lazy. I might do it eventually though.

## how to create mods

from the "data_webfishing_2_newver/Assemblies" folder you can find WebfishingMonoLoader.dll which is the api you need to create a mod.

Create a new class library C# project and use this [base class](https://github.com/Kade-github/MonoLoader-Webfishing/blob/main/BaseMod/BaseMod/BaseMod.cs) as a template. Otherwise it's just a Godot Node so. You can also include Webfishing.dll and GodotSharp.dll for some more references.
