using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UpdateManagerComponent: MonoBehaviour
{
    UpdateManager updateManager;

    public void SetUpdateManager(UpdateManager updateManager)
    {
        this.updateManager = updateManager;
    }

    private void Update() => updateManager.Tick();
    private void FixedUpdate() => updateManager.TickFixed();
    private void LateUpdate() => updateManager.TickLate();
}

