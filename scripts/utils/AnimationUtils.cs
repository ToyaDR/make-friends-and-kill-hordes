
using Godot;

public static class AnimationUtils
{
  public static void PrintQueue(string[] queue)
  {
    GD.Print(string.Format("[{0}]\n", queue.Join(",")));
  }
}