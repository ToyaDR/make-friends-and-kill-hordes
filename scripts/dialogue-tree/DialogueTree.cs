using System;

public class DialogueTree
{
  private NPCDialogue start;
  public NPCDialogue Start
  {
    get { return start; }
    set { start = value; }
  }

  public DialogueTree(NPCDialogue startDialogue)
  {
    start = startDialogue;
  }
}