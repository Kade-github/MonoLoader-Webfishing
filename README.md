# MonoLoader-Webfishing
A C# Mono DLL Loader for Webfishing

**This; itself, is not a mod that does anything. It only loads other mods that COULD do something**

## instructions

install [GDWeave](https://github.com/NotNite/GDWeave/tree/main/GDWeave), and then extract the [latest release](https://github.com/Kade-github/MonoLoader-Webfishing/releases/latest) into your main webfishing folder. 

It should look like this

![image](https://github.com/user-attachments/assets/0b770521-bb61-4185-b99f-99e32563ae32)

Then launch the game, and it should create a mono_mods folder in the same directory you extracted everything in.

You can now install mods into that folder (by dragging the .dll's into them)

## how to create mods

Inside `data_webfishing_2_newver\Assemblies` you will find `WebfishingMonoLoader.dll` which is the main api that you will use to get the game to recogonize your mono mods.

Check out the [base mod](https://github.com/Kade-github/MonoLoader-Webfishing/blob/main/BaseMod/BaseMod/BaseMod.cs) for an example
