using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace MonoLoader_Weave;

public class MonoLoader_GDWeave: IScriptMod {
  public bool ShouldRun(string path) =>path == "res://Scenes/Singletons/globals.gdc";

  public IEnumerable < Token > Modify(string path, IEnumerable < Token > tokens) {
    bool enterTree = false;
    var extendsWaiter = new MultiTokenWaiter([
    t =>t.Type is TokenType.PrExtends, t =>t.Type is TokenType.Newline], allowPartialMatch: true);

    foreach(var token in tokens) {
      if (extendsWaiter.Check(token)) {
        if (!enterTree) {
          enterTree = true;
          yield return token;
          foreach (var t in CreateEnterTree()) yield return t;
        }
      }
      else
        yield return token;
    }
  }
  
  // func _enter_tree():
  //    ProjectSettings.load_resource_pack("MonoLoader.pck")
  //    var monoloader = load("res://monoloader/monoloader.tscn").instance()
  //    get_tree().get_root().call_deferred("add_child", monoloader)
  private IEnumerable <Token>CreateEnterTree() {
    
    yield return new Token(TokenType.PrFunction);
    yield return new IdentifierToken("_enter_tree");
    yield return new Token(TokenType.ParenthesisOpen);
    yield return new Token(TokenType.ParenthesisClose);
    yield return new Token(TokenType.Colon);
    yield return new Token(TokenType.Newline, 1);

    yield return new IdentifierToken("ProjectSettings");
    yield return new Token(TokenType.Period);
    yield return new IdentifierToken("load_resource_pack");
    yield return new Token(TokenType.ParenthesisOpen);
    yield return new ConstantToken(new StringVariant("MonoLoader.pck"));
    yield return new Token(TokenType.ParenthesisClose);
    yield return new Token(TokenType.Newline, 1);
    
    yield return new Token(TokenType.PrVar);
    yield return new IdentifierToken("monoloader");
    yield return new Token(TokenType.OpAssign);
    yield return new Token(TokenType.BuiltInFunc, (uint ? ) BuiltinFunction.ResourceLoad);
    yield return new Token(TokenType.ParenthesisOpen);
    yield return new ConstantToken(new StringVariant("res://monoloader.tscn"));
    yield return new Token(TokenType.ParenthesisClose);
    yield return new Token(TokenType.Period);
    yield return new IdentifierToken("instance");
    yield return new Token(TokenType.ParenthesisOpen);
    yield return new Token(TokenType.ParenthesisClose);
    yield return new Token(TokenType.Newline, 1);
    
    yield return new IdentifierToken("get_tree");
    yield return new Token(TokenType.ParenthesisOpen);
    yield return new Token(TokenType.ParenthesisClose);
    yield return new Token(TokenType.Period);
    yield return new IdentifierToken("get_root");
    yield return new Token(TokenType.ParenthesisOpen);
    yield return new Token(TokenType.ParenthesisClose);
    yield return new Token(TokenType.Period);
    yield return new IdentifierToken("call_deferred");
    yield return new Token(TokenType.ParenthesisOpen);
    yield return new ConstantToken(new StringVariant("add_child"));
    yield return new Token(TokenType.Comma);
    yield return new IdentifierToken("monoloader");
    yield return new Token(TokenType.ParenthesisClose);
    yield return new Token(TokenType.Newline, 1);

    yield return new Token(TokenType.BuiltInFunc, (uint ? ) BuiltinFunction.TextPrint);
    yield return new Token(TokenType.ParenthesisOpen);
    yield return new ConstantToken(new StringVariant("Added monoloader to scene tree"));
    yield return new Token(TokenType.ParenthesisClose);
    yield return new Token(TokenType.Newline);
    yield return new Token(TokenType.Newline, 1);
  }
}