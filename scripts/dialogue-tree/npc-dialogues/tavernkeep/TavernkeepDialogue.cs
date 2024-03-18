
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
    DialogueOption[] startResponses = new DialogueOption[3];

    DialogueOption[] exitResponse = new DialogueOption[1];
    exitResponse[0] = new DialogueOption("Exit", null, true);

    startResponses[0] = new DialogueOption("I slept very soundly.", new NPCDialogue("That's good to hear!", exitResponse));
    startResponses[1] = new DialogueOption("Of course!", new NPCDialogue("That's good to hear!", exitResponse));
    startResponses[2] = new DialogueOption("Of course!1", new NPCDialogue("That's good to hear!", exitResponse));

    NPCDialogue start = new NPCDialogue("Good mornin' hon! Slept well I hope?", startResponses);
    tree = new DialogueTree(start, "res://scenes/locations/Tavern.tscn");
  }
}