
using System;
using Godot;

public static class Utilities
{
  public static uint[] GetCollisionLayer(uint mask)
  {
    uint[] binaryNum = new uint[32];

    uint i = 0;
    uint maskCopy = mask;
    while (maskCopy > 0)
    {
      binaryNum[i] = maskCopy % 2;
      maskCopy /= 2;
      i++;
    }

    // Array.Reverse(binaryNum);
    return binaryNum;
  }

  public static bool IsInCollisionLayer(uint layer, uint mask)
  {
    if (layer > 32 || layer == 0) { return false; }
    uint[] processedMask = GetCollisionLayer(mask);
    // GD.Print("=====");
    // for (int j = 0; j < 32; j++)
    // {
    //   GD.Print(processedMask[j]);
    // }
    // GD.Print("=====");
    return processedMask[layer - 1] == 1;
  }
}