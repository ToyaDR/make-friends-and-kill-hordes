using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using Godot.Collections;

public class SpellsLoader
{
  private static Godot.Collections.Dictionary<string, Variant> wordsDict;
  private static System.Collections.Generic.Dictionary<string, Word> words;
  private static Godot.Collections.Dictionary<string, Variant> spellsDict;
  private static System.Collections.Generic.Dictionary<string, Spell> spells;
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

  private static void SetWords()
  {
    words = wordsDict.Keys.Aggregate(new System.Collections.Generic.Dictionary<string, Word>() { }, (acc, word) =>
    {
      Godot.Collections.Dictionary<string, Variant> wordAttributes = (Godot.Collections.Dictionary<string, Variant>)wordsDict.GetValueOrDefault(word);


      string[] spellList = ((Array<string>)wordAttributes.GetValueOrDefault("spells")).Aggregate(System.Array.Empty<string>(), (spellArr, spellId) =>
      {
        return spellArr.Append(spellId).Cast<string>().ToArray();
      });
      string rune = (string)wordAttributes.GetValueOrDefault("runePath");
      string id = (string)wordAttributes.GetValueOrDefault("id");
      acc.Add(word, new Word(spellList, rune, id, word));

      return acc;
    });
  }

  private static void SetSpells()
  {
    spells = spellsDict.Keys.Aggregate(new System.Collections.Generic.Dictionary<string, Spell>() { }, (acc, word) =>
    {
      Godot.Collections.Dictionary<string, Variant> spellAttributes = (Godot.Collections.Dictionary<string, Variant>)spellsDict.GetValueOrDefault(word);

      string[] wordList = ((Array<string>)spellAttributes.GetValueOrDefault("words")).Aggregate(System.Array.Empty<string>(), (wordArr, wordId) =>
      {
        return wordArr.Append(wordId).Cast<string>().ToArray();
      });
      string rune = (string)spellAttributes.GetValueOrDefault("runePath");
      string id = (string)spellAttributes.GetValueOrDefault("id");
      acc.Add(word, new Spell(wordList, rune, id, word));

      return acc;
    });
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
    SetSpells();
    PrintDictionary(spells);

    SetWords();
    PrintDictionary(words);
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