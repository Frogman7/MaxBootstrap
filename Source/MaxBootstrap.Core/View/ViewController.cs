using System.Collections.Generic;
using System.Linq;
using MaxBootstrap.UI;
using System;
using System.ComponentModel;
using MaxBootstrap.Core.Enums;

namespace MaxBootstrap.Core.View
{
    public class ViewController : IViewController
    {
        public event Action<Sequence> SequenceStarted;

        public event Action<IView> ViewChange;

        public ButtonStateManager ButtonStateManager { get; protected set; }

        private IList<string> sequence;

        private IView currentView;

        private ushort sequenceIndex;

        public IView CurrentView
        {
            get
            {
                if (this.currentView == null)
                {
                    this.currentView = this.ViewCollection.GetView(this.ViewCollection.StartPage);
                }

                return this.currentView;
            }

            protected set
            {
                this.currentView = value;
                
                if (this.ViewChange != null)
                {
                    this.ViewChange(this.currentView);
                }
            }
        }

        public ViewCollection ViewCollection { get; protected set; }

        public ViewController(ViewCollection pageCollection)
        {
            this.ViewCollection = pageCollection;
            this.CurrentView = this.ViewCollection.GetView(this.ViewCollection.StartPage);
            this.ButtonStateManager = new ButtonStateManager();

            this.ButtonStateManager.NextButton.Command = new DelegateCommand(this.GoNext);
            this.ButtonStateManager.BackButton.Command = new DelegateCommand(this.GoBack);
            this.ButtonStateManager.InstallButton.Command = new DelegateCommand(this.StartInstallSequence);
            this.ButtonStateManager.UninstallButton.Command = new DelegateCommand(this.StartUninstallSequence);
            this.ButtonStateManager.UpgradeButton.Command = new DelegateCommand(this.StartUpgradeSequence);
            this.ButtonStateManager.ModifyButton.Command = new DelegateCommand(this.StartModifySequence);
            this.ButtonStateManager.RepairButton.Command = new DelegateCommand(this.StartRepairSequence);
            this.ButtonStateManager.CancelButton.Command = new DelegateCommand(this.GoToCancelView);
        }

        public void GoBack()
        {
            if (this.sequenceIndex > 0)
            {
                this.CurrentView = this.ViewCollection.GetView(this.sequence[--this.sequenceIndex]);
            }
            else if (this.sequenceIndex == 0)
            {
                // TODO Consider maybe exiting instead of going all the way back to start
                this.CurrentView = this.ViewCollection.GetView(this.ViewCollection.StartPage);

                this.ButtonStateManager.BackButton.Visible = false;
            }

            // TODO Throw error of some kind on else condition
        }

        public void GoNext()
        {
            if (this.sequenceIndex < this.sequence.Count)
            {
                this.CurrentView = this.ViewCollection.GetView(this.sequence[++this.sequenceIndex]);
            }

            // TODO Throw error of some kind on else condition
        }

        public void StartInstallSequence()
        {
            this.StartSequence(Sequence.Install);
        }

        public void StartUninstallSequence()
        {
            this.StartSequence(Sequence.Uninstall);
        }

        public void StartUpgradeSequence()
        {
            this.StartSequence(Sequence.Upgrade);
        }

        public void StartModifySequence()
        {
            this.StartSequence(Sequence.Modify);
        }

        public void StartRepairSequence()
        {
            this.StartSequence(Sequence.Repair);
        }

        public void GoToErrorView()
        {
            this.CurrentView = this.ViewCollection.GetView(this.ViewCollection.ErrorPage);
        }

        public void GoToCancelView()
        {
            this.CurrentView = this.ViewCollection.GetView(this.ViewCollection.CancelPage);
        }

        private void StartSequence(Sequence sequence)
        {
            this.ButtonStateManager.InstallButton.Visible = false;
            this.ButtonStateManager.UninstallButton.Visible = false;
            this.ButtonStateManager.ModifyButton.Visible = false;
            this.ButtonStateManager.UpgradeButton.Visible = false;
            this.ButtonStateManager.RepairButton.Visible = false;

            this.ButtonStateManager.NextButton.Visible = true;
            this.ButtonStateManager.BackButton.Visible = true;

            this.sequenceIndex = 0;

            switch (sequence)
            {
                case Sequence.Install:
                    {
                        this.sequence = this.ViewCollection.InstallSequence.ToList();
                        break;
                    }
                case Sequence.Modify:
                    {
                        this.sequence = this.ViewCollection.ModifySequence.ToList();
                        break;
                    }
                case Sequence.Upgrade:
                    {
                        this.sequence = this.ViewCollection.UpgradeSequence.ToList();
                        break;
                    }
                case Sequence.Repair:
                    {
                        this.sequence = this.ViewCollection.RepairSequence.ToList();
                        break;
                    }
                case Sequence.Uninstall:
                    {
                        this.sequence = this.ViewCollection.UninstallSequence.ToList();
                        break;
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException(nameof(sequence), (int)sequence, typeof(Sequence));
                    }
            }

            if (this.SequenceStarted != null)
            {
                this.SequenceStarted(sequence);
            }

            this.CurrentView = this.ViewCollection.GetView(this.sequence[0]);
        }
    }
}
