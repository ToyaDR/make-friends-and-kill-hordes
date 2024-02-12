
using Godot;

public partial class Interactable : StaticBody3D
{
  public void Interact()
  {
    // eventually would like this to set the interact message to the screen
    GD.Print("Interact");
  }
}