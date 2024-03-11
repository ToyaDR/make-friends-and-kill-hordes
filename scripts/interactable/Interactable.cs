
using Godot;

public partial class Interactable : StaticBody3D
{
  public virtual void Interact()
  {
    GD.Print("Interact");
  }
  public virtual void ExitInteraction()
  {
    GD.Print("ExitInteraction");
  }
}