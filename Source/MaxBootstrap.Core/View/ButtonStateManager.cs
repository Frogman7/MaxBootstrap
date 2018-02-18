using System.Collections;
using System.Collections.Generic;

namespace MaxBootstrap.Core.View
{
    public class ButtonStateManager : IEnumerable<ButtonState>
    {
        public ButtonState NextButton { get; protected set; }

        public ButtonState BackButton { get; protected set; }

        public ButtonState CancelButton { get; protected set; }

        public ButtonState InstallButton { get; protected set; }

        public ButtonState UninstallButton { get; protected set; }

        public ButtonState UpgradeButton { get; protected set; }

        public ButtonState ModifyButton { get; protected set; }

        public ButtonState RepairButton { get; protected set; }

        public ButtonStateManager()
        {
            this.NextButton = new ButtonState("Next", true, false);
            this.BackButton = new ButtonState("Back", true, false);
            this.CancelButton = new ButtonState("Cancel", true, false);
            this.InstallButton = new ButtonState("Install", true, false);
            this.UninstallButton = new ButtonState("Uninstall", true, false);
            this.UpgradeButton = new ButtonState("Upgrade", true, false);
            this.ModifyButton = new ButtonState("Modify", true, false);
            this.RepairButton = new ButtonState("Repair", true, false);
        }

        public IEnumerator<ButtonState> GetEnumerator()
        {
            IList<ButtonState> buttonStateList = new List<ButtonState>();
            buttonStateList.Add(this.CancelButton);
            buttonStateList.Add(this.BackButton);
            buttonStateList.Add(this.InstallButton);
            buttonStateList.Add(this.UninstallButton);
            buttonStateList.Add(this.UpgradeButton);
            buttonStateList.Add(this.ModifyButton);
            buttonStateList.Add(this.RepairButton);
            buttonStateList.Add(this.NextButton);

            return buttonStateList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
