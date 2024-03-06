using System;

public class DialogueTree
{
  private NPCDialogue start;
  public NPCDialogue Start
  {
    get { return start; }
    set { start = value; }
  }
  private string exitScene;
  public string ExitScene
  {
    get { return exitScene; }
  }

  public DialogueTree(NPCDialogue startDialogue, string exit)
  {
    start = startDialogue;
    exitScene = exit;
  }
}