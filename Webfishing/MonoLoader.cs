using Godot;
using System;
using webfishing.Scenes;
using WebfishingMonoLoader;

public class MonoLoader : Node
{
    
    
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    
    
    public override void _Ready()
    {
		if (!ModManager.Instance.Initialized)
            ModManager.Instance.Initialize();
        
        // add all of our mods
        
        foreach(Mod mod in ModManager.Instance.Mods)
            AddChild(mod);
        
        GD.Print("Added all mods to scene");
        
    }

    public override void _ExitTree()
    {
        foreach (Mod mod in ModManager.Instance.Mods)
            RemoveChild(mod);
        GD.Print("Removed all mods from scene");
    }
}
