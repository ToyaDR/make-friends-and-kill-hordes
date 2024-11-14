
using System;
using Godot;

public class Spell
{

  private string spellName;
  public string SpellName
  {
    get => spellName;
  }

  private string[] wordIds;
  public string[] WordIds
  {
    get => wordIds;
  }

  private string runePath;
  public string RunePath
  {
    get => runePath;
  }

  private string spellId;
  public string SpellId
  {
    get => spellId;
  }

  public Spell(string[] words, string rune, string spell, string name)
  {
    wordIds = words;
    runePath = rune;
    spellId = spell;
    spellName = name;
  }

  public override string ToString()
  {
    return String.Format("\nspellId: {0}\nspellName: {1}\nrunePath: {2}\nwordIds: [{3}]", spellId, spellName, runePath, wordIds.Join(","));
  }
}