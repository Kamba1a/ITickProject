using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UpdateManager : MonoBehaviour, ITick, ITickFixed, ITickLate
{
    private List<ITick> ticks = new List<ITick>();
    private List<ITickLate> ticksLate = new List<ITickLate>();
    private List<ITickFixed> ticksFixed = new List<ITickFixed>();

    private void Awake()
    {
        FindObjectOfType<Starter>().gameObject.AddComponent<UpdateManagerComponent>().SetUpdateManager(this);
    }

    public static void Add(ITick tick) => Toolbox.GetOrCreate<UpdateManager>().ticks.Add(tick);
    public static void Add(ITickLate tickLate) => Toolbox.GetOrCreate<UpdateManager>().ticksLate.Add(tickLate);
    public static void Add(ITickFixed tickFixed) => Toolbox.GetOrCreate<UpdateManager>().ticksFixed.Add(tickFixed);

    public void Tick()
    {
        for (int i = 0; i < ticks.Count; i++)
        {
            ticks[i].Tick();
        }
    }

    public void TickFixed()
    {
        for (int i = 0; i < ticksFixed.Count; i++)
        {
            ticksFixed[i].TickFixed();
        }
    }

    public void TickLate()
    {
        for (int i = 0; i < ticksLate.Count; i++)
        {
            ticksLate[i].TickLate();
        }
    }
}
