
using System;
using Godot;

public partial class Word
{

  private string wordName;
  public string WordName
  {
    get => wordName;
  }

  private string[] spellIds;
  public string[] SpellIds
  {
    get => spellIds;
  }
  private string runePath;
  public string RunePath
  {
    get => runePath;
  }

  private string wordId;
  public string WordId
  {
    get => wordId;
  }


  public Word(string[] spells, string rune, string word, string name)
  {
    spellIds = spells;
    runePath = rune;
    wordId = word;
    wordName = name;
  }

  public override string ToString()
  {
    return String.Format("\nwordId: {0}\nwordName: {1}\nrunePath: {2}\nspellIds: [{3}]", wordId, wordName, runePath, spellIds.Join(","));
  }
}