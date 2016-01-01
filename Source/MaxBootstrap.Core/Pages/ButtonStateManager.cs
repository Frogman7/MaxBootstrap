namespace MaxBootstrap.Core.Pages
{
    public class ButtonStateManager
    {
        public ButtonState NextButton { get; protected set; }

        public ButtonState BackButton { get; protected set; }

        public ButtonState CancelButton { get; protected set; }

        public ButtonState UpgradeButton { get; protected set; }

        public ButtonState ModifyButton { get; protected set; }

        public ButtonState RepairButton { get; protected set; }

        public ButtonStateManager()
        {
            this.NextButton = new ButtonState("Next", true, true);
            this.BackButton = new ButtonState("Previous", true, false);
            this.CancelButton = new ButtonState("Cancel", true, false);
            this.UpgradeButton = new ButtonState("Upgrade", true, false);
            this.ModifyButton = new ButtonState("Modify", true, false);
            this.RepairButton = new ButtonState("Repair", true, false);
        }
    }
}
