using Godot;
using WebfishingMonoLoader;

namespace BaseMod
{
    public class BaseMod : Mod
    {
        public override void _Ready()
        {
            GD.Print("Base Mod Ready");
        }

        public override void Load()
        {
            GD.Print("Base Mod loaded");
        }

        public override string Name { get; set; } = "BaseMod";
        public override string Author { get; set; } = "KadeDev";
    }
}