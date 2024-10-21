using GDWeave;

namespace MonoLoader_Weave;

public class Mod : IMod {
    public Mod(IModInterface modInterface) {
        modInterface.RegisterScriptMod(new MonoLoader_GDWeave());
    }

    public void Dispose() { }
}