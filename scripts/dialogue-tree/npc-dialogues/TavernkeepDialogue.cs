
public class TavernkeepDialogue
{
  private DialogueTree tree;
  public DialogueTree Tree
  {
    get { return tree; }
    set { tree = value; }
  }

  public TavernkeepDialogue()
  {
    DialogueOption[] startResponses = new DialogueOption[2];
    startResponses[0] = new DialogueOption("I slept very soundly.", new NPCDialogue("That's good to hear!", null));
    startResponses[1] = new DialogueOption("Of course!", new NPCDialogue("That's good to hear!", null));

    NPCDialogue start = new NPCDialogue("Good mornin' hon! Slept well I hope?", startResponses);
    tree = new DialogueTree(start);
  }
}