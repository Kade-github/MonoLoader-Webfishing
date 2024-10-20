# MonoLoader-Webfishing
A C# Mono DLL Loader for Webfishing

**This; itself, is not a mod that does anything. It only loads other mods that COULD do something**

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

## how does this even work

So the general idea is that we compile [GodotSteam](https://github.com/GodotSteam/GodotSteam) to use the mono version of godot. Then we take the compiled player and use that to run the game. Then we add the scripts from the "Webfishing" directory in this repo and add MonoLoader.cs as an autoload.

Then we only export those files to the decompiled project of webfishing, and use it as the to_merge.pck file. and boom. you are done.
