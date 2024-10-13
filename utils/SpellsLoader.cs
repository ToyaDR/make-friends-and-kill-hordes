using Godot;
using Godot.Collections;

public class SpellsLoader
{
  public static void LoadSpells()
  {
    string wordsFileAsText = FileAccess.GetFileAsString("res://assets/dictionary/spells.json");
    // string spellsFileAsText = FileAccess.GetFileAsString("res://assets/dictionary/words.json");
    Dictionary wordsFileAsDict = (Dictionary)Json.ParseString(wordsFileAsText);

    GD.Print(wordsFileAsDict);
  }
}