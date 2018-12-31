using MaxBootstrap.Core.Enums;
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

        public virtual void ChangeState(InstallerStage stage)
        {
            switch (stage)
            {
                case InstallerStage.Initializing:
                    {
                        this.BackButton.Visible = false;
                        this.NextButton.Visible = false;
                        this.CancelButton.Visible = false;
                        this.InstallButton.Visible = false;
                        this.UninstallButton.Visible = false;
                        this.UpgradeButton.Visible = false;
                        this.ModifyButton.Visible = false;
                        this.RepairButton.Visible = false;

                        break;
                    }
                case InstallerStage.StartupNotPresent:
                    {
                        this.InstallButton.Visible = true;

                        break;
                    }
                case InstallerStage.StartupPresent:
                    {
                        this.UninstallButton.Visible = true;
                        this.ModifyButton.Visible = true;
                        this.RepairButton.Visible = true;
                        this.RepairButton.Enabled = false;

                        break;
                    }
                case InstallerStage.StartupUpgrade:
                    {
                        this.UpgradeButton.Visible = true;

                        break;
                    }
                case InstallerStage.Configuration:
                    {
                        this.InstallButton.Visible = false;
                        this.UninstallButton.Visible = false;
                        this.ModifyButton.Visible = false;
                        this.RepairButton.Visible = false;
                        this.UpgradeButton.Visible = false;

                        this.NextButton.Visible = true;
                        this.BackButton.Visible = true;

                        break;
                    }
                case InstallerStage.Processing:
                    {
                        this.BackButton.Visible = false;
                        this.CancelButton.Visible = true;
                        this.NextButton.Enabled = false;

                        break;
                    }
                case InstallerStage.Finished:
                    {
                        this.CancelButton.Visible = false;

                        this.NextButton.Text = "Finish";
                        this.NextButton.Visible = true;
                        this.NextButton.Enabled = true;
                        this.NextButton.Command = new UI.DelegateCommand(() => { System.Environment.Exit(0); });

                        break;
                    }
                case InstallerStage.Error:
                    {
                        this.CancelButton.Visible = false;

                        this.NextButton.Text = "Exit";
                        this.NextButton.Enabled = true;

                        break;
                    }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}