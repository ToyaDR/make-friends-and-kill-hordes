using System;

public class DialogueOption
{
  private string text;
  public string Text
  {
    get { return text; }
    set { text = value; }
  }

  public bool isExit;

  private NPCDialogue result;
  public NPCDialogue Result
  {
    get { return result; }
    set { result = value; }
  }

  public DialogueOption(string OptionText, NPCDialogue DialogueResult)
  {
    text = OptionText;
    result = DialogueResult;
    isExit = false;
  }
  public DialogueOption(string OptionText, NPCDialogue DialogueResult, bool ExitResponse)
  {
    text = OptionText;
    result = DialogueResult;
    isExit = ExitResponse;
  }
}