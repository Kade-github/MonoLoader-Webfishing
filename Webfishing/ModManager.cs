using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Godot;
using WebfishingMonoLoader;
using Directory = System.IO.Directory;
using Path = System.IO.Path;

namespace webfishing.Scenes
{
    public class ModManager
    {
        public static ModManager Instance { get; } = new ModManager();
        
        public List<Mod> Mods { get; set; } = new List<Mod>();
        
        public bool Initialized { get; private set; } = false;

        public void Initialize()
        {
            // load all mods in mono_mods/

            if (!Directory.Exists("mono_mods"))
            {
                Directory.CreateDirectory("mono_mods");
            }
            var fullName = typeof(Mod).Name;
            foreach (string f in Directory.GetFiles("mono_mods", "*.dll"))
            {
                string p = Path.GetFullPath(f);
                Assembly assembly = null;
                try
                {
                    GD.Print("Loading " + p);
                    assembly = Assembly.LoadFile(p);
                    
                }
                catch (Exception e)
                {
                    GD.PrintErr("[ERROR] ERROR LOADING ASSEMBLY: " + e.Message);
                    continue;
                }
                if (fullName != null)
                {
                    GD.Print("Finding " + fullName);
                    Type m = assembly.GetTypes().FirstOrDefault(t => t.BaseType != null && t.BaseType.FullName == "WebfishingMonoLoader.Mod");
                    if (m == null)
                    {
                        GD.PrintErr("Failed to load mod " + p + ". Is there a class that inherits WebfishingMonoLoader.Mod?");
                    }
                    else
                    {
                        Mod mod = (Mod)Activator.CreateInstance(m);
                        Mods.Add(mod);
                        mod.Load();
                        GD.Print("Loaded " + mod.Name + " by " + mod.Author);
                    }
                    
                    
                }
            }

            Initialized = true;
            
            GD.Print("MonoLoader Initialized");
        }
    }
}