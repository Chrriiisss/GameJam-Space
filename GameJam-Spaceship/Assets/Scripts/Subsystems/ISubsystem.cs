
public interface ISubsystem{
    int GetHealth();
    void TakeDamage(int damageAmount);
    void Repair();
    int GetPercentHealth();
    string ToString();
    string GetDescription();
}
