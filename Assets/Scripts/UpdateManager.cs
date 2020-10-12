using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UpdateManager : MonoBehaviour, ITick, ITickFixed, ITickLate
{
    List<ITick> ticks = new List<ITick>();
    List<ITickLate> ticksLate = new List<ITickLate>();
    List<ITickFixed> ticksFixed = new List<ITickFixed>();

    void Awake()
    {
        FindObjectOfType<Starter>().gameObject.AddComponent<UpdateManagerComponent>().SetUpdateManager(this);
    }

    static public void Add(ITick tick) => Toolbox.GetOrCreate<UpdateManager>().ticks.Add(tick);
    static public void Add(ITickLate tickLate) => Toolbox.GetOrCreate<UpdateManager>().ticksLate.Add(tickLate);
    static public void Add(ITickFixed tickFixed) => Toolbox.GetOrCreate<UpdateManager>().ticksFixed.Add(tickFixed);

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
