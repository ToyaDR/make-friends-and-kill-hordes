using System;

public class NPCDialogue
{
  private string text;
  public string Text
  {
    get { return text; }
    set { text = value; }
  }

  private DialogueOption[] responses;
  public DialogueOption[] Responses
  {
    get { return responses; }
    set { responses = value; }
  }

  public NPCDialogue(string DialogueText, DialogueOption[] ResponseOptions)
  {
    text = DialogueText;
    responses = ResponseOptions;
  }
}