using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItems : MonoBehaviour
{
    [SerializeField] Game GameScript;
    private void Awake()
    {
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
    }
    public void GoldBalance(double count)
    {
        GameScript.balance += count;
    }
    public void CrystalBalance(double count)
    {
        GameScript.balanceCrystal += count;
    }

    public void Chest1(int count)
    {
        GameScript.chests[0] += count;
    }
    public void Chest2(int count)
    {
        GameScript.chests[1] += count;
    }
    public void Chest3(int count)
    {
        GameScript.chests[2] += count;
    }
    public void Chest4(int count)
    {
        GameScript.chests[3] += count;
    }
    public void Chest5(int count)
    {
        GameScript.chests[4] += count;
    }
    public void Chest6(int count)
    {
        GameScript.chests[5] += count;
    }
    public void Chest7(int count)
    {
        GameScript.chests[6] += count;
    }
    public void Chest8(int count)
    {
        GameScript.chests[7] += count;
    }


    public void SpeedPotion1Level(int count)
    {
        GameScript.potions[0] += count;
    }
    public void SpeedPotion2Level(int count)
    {
        GameScript.potions[1] += count;
    }
    public void SpeedPotion3Level(int count)
    {
        GameScript.potions[2] += count;
    }
    public void SpeedPotion4Level(int count)
    {
        GameScript.potions[3] += count;
    }

    public void BaksPotion1Level(int count)
    {
        GameScript.potions[4] += count;
    }
    public void BaksPotion2Level(int count)
    {
        GameScript.potions[5] += count;
    }
    public void BaksPotion3Level(int count)
    {
        GameScript.potions[6] += count;
    }
    public void BaksPotion4Level(int count)
    {
        GameScript.potions[7] += count;
    }

    public void AutiClickPotion1Level(int count)
    {
        GameScript.potions[8] += count;
    }
    public void AutiClickPotion2Level(int count)
    {
        GameScript.potions[9] += count;
    }
    public void AutiClickPotion3Level(int count)
    {
        GameScript.potions[10] += count;
    }
    public void AutiClickPotion4Level(int count)
    {
        GameScript.potions[11] += count;
    }
}
