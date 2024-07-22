
public class HitPoints
{
  private int totalHitPoints;
  public int TotalHitPoints { get => totalHitPoints; }

  private int currentHitPoints;
  public int CurrentHitPoints { get => currentHitPoints; }

  public HitPoints(int totalHP)
  {
    currentHitPoints = totalHP;
    totalHitPoints = totalHP;
  }

  /*
   * TakeDamage
   * Takes an int representing the amount of damage dealt to the character
   * that these HitPoints belong to
   * Returns an int representing the new current hit points of the character
   */
  public int TakeDamage(int damage)
  {
    currentHitPoints -= damage;
    return currentHitPoints;
  }

  /*
   * ReceiveHealing
   * Takes an int representing the amount of healing granted to the character
   * that these HitPoints belong to
   * Returns an int representing the new current hit points of the character
   */
  public int ReceiveHealing(int healing)
  {
    currentHitPoints += healing;
    return currentHitPoints;
  }
}