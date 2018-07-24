﻿using EarTrumpet.Extensibility;
using EarTrumpet.UI.Helpers;
using EarTrumpet.UI.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace EarTrumpet_Actions
{
    [Export(typeof(IAddonContextMenu))]
    public class ContextMenuAddon : IAddonContextMenu
    {
        public IEnumerable<ContextMenuItem> Items
        {
            get
            {
                var ret = new List<ContextMenuItem>();
                ret.Add(new ContextMenuItem { DisplayName = "Edit actions and hotkeys", Command = new RelayCommand(() => OpenActionEditor()) });
                if (ActionsManager.Instance.Actions.Any())
                {
                    ret.Add(new ContextMenuItem
                    {
                        DisplayName = "My actions",
                        Children = ActionsManager.Instance.Actions.
                        Select(a => new ContextMenuItem { DisplayName = a.DisplayName, Command = new RelayCommand(() => a.ManualTrigger()) })
                    });
                }
                return ret;
            }
        }

        private void OpenActionEditor()
        {
          //  SettingsWindow.ActivateSingleInstance(new ActionsEditor(), "Edit Actions");
        }
    }
}
