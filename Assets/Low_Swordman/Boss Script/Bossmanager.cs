using UnityEngine;

public class BossManager : MonoBehaviour
{
    public Boss boss1; // Reference to Boss 1 script
    public Boss boss2; // Reference to Boss 2 script
    public SceneFader screenFade; // Reference to your screen fade logic

    private bool isBoss1Dead = false;
    private bool isBoss2Dead = false;

    void Update()
    {
        // Check if both bosses are dead
        if (isBoss1Dead && isBoss2Dead)
        {
            // Trigger the screen fade
            screenFade.StartFadeOut();
        }
    }

    // Call this when Boss 1 dies
    public void Boss1Died()
    {
        isBoss1Dead = true;
        CheckIfBothBossesAreDead();
    }

    // Call this when Boss 2 dies
    public void Boss2Died()
    {
        isBoss2Dead = true;
        CheckIfBothBossesAreDead();
    }

    void CheckIfBothBossesAreDead()
    {
        if (isBoss1Dead && isBoss2Dead)
        {
            screenFade.StartFadeOut(); // Trigger fade only when both are dead
        }
    }
}

