using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using Godot.Collections;

public class SpellsLoader
{
  private static Godot.Collections.Dictionary<string, Variant> wordsDict;
  private static Godot.Collections.Dictionary<string, Variant> spellsDict;
  private static System.Collections.Generic.Dictionary<string, Array<string>> spellToWordsDict;
  private static System.Collections.Generic.Dictionary<string, string> wordIdToNameDict;

  private static void PrintDictionary<TKey, TValue>(System.Collections.Generic.Dictionary<TKey, TValue> dict)
  {
    GD.Print("========START=======");
    foreach (var kv in dict)
    {
      GD.Print(String.Format("<{0}, {1}>", kv.Key, kv.Value));
    }
    GD.Print("========END=======");
  }

  public static void LoadSpells()
  {
    string wordsFileAsText = FileAccess.GetFileAsString("res://assets/dictionary/words.json");
    string spellsFileAsText = FileAccess.GetFileAsString("res://assets/dictionary/spells.json");
    wordsDict = (Godot.Collections.Dictionary<string, Variant>)Json.ParseString(wordsFileAsText);
    spellsDict = (Godot.Collections.Dictionary<string, Variant>)Json.ParseString(spellsFileAsText);

    wordIdToNameDict = wordsDict.Keys.Aggregate(new System.Collections.Generic.Dictionary<string, string>() { }, (acc, word) =>
    {
      Godot.Collections.Dictionary<string, Variant> wordAttributes = (Godot.Collections.Dictionary<string, Variant>)wordsDict.GetValueOrDefault(word);

      string wordId = (string)wordAttributes.GetValueOrDefault("id");
      acc.Add(wordId, word);
      return acc;
    });
    // PrintDictionary(wordIdToNameDict);

    spellToWordsDict = spellsDict.Keys.Aggregate(new System.Collections.Generic.Dictionary<string, Array<string>>() { }, (acc, spell) =>
    {
      Godot.Collections.Dictionary<string, Variant> spellAttributes = (Godot.Collections.Dictionary<string, Variant>)spellsDict.GetValueOrDefault(spell);

      Array<string> wordsInSpell = (Array<string>)spellAttributes.GetValueOrDefault("words");

      acc.Add(spell, wordsInSpell);
      return acc;
    });

    // PrintDictionary(spellToWordsDict);
  }

  public static Array<string> GetWordsForSpell(string spellId)
  {
    return spellToWordsDict.GetValueOrDefault(spellId);
  }

  public static Array<string> GetWordNamesForSpell(string spellId)
  {
    return (Array<string>)spellToWordsDict.GetValueOrDefault(spellId)
      .Select(word => wordIdToNameDict.GetValueOrDefault(word));
  }
}