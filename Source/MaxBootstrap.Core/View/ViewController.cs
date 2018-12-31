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

        public event Action<IViewmodel> ViewChange;

        public ButtonStateManager ButtonStateManager { get; protected set; }

        private IList<string> sequence;

        private IViewmodel currentView;

        private ushort sequenceIndex;

        public IViewmodel CurrentViewmodel
        {
            get
            {
                if (this.currentView == null)
                {
                    this.currentView = this.ViewCollection.GetViewmodel(this.ViewCollection.StartPage);
                    this.currentView.OnNavigatedTo();
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

            if (!string.IsNullOrEmpty(this.ViewCollection.StartPage))
            {
                this.CurrentViewmodel = this.ViewCollection.GetViewmodel(this.ViewCollection.StartPage);
                this.CurrentViewmodel.OnNavigatedTo();
            }

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
                this.Navigate(this.ViewCollection.GetViewmodel(this.sequence[--this.sequenceIndex]));

                if (this.sequenceIndex == 0)
                {
                    this.ButtonStateManager.BackButton.Visible = false;
                    this.ButtonStateManager.CancelButton.Visible = true;
                }
            }

            // TODO Throw error of some kind on else condition
        }

        public void GoNext()
        {
            if (this.sequenceIndex < this.sequence.Count)
            {
                if (this.sequenceIndex == 0)
                {
                    this.ButtonStateManager.BackButton.Visible = true;
                    this.ButtonStateManager.CancelButton.Visible = false;
                }

                this.sequenceIndex++;

                this.Navigate(this.ViewCollection.GetViewmodel(this.sequence[this.sequenceIndex]));
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
            this.CurrentViewmodel.OnNavigatedFrom();

            this.CurrentViewmodel = this.ViewCollection.GetViewmodel(this.ViewCollection.ErrorPage);

            this.CurrentViewmodel.OnNavigatedTo();

            this.InstallStageChange(InstallerStage.Error);
        }

        public void GoToCancelView()
        {
            this.CurrentViewmodel.OnNavigatedFrom();

            this.CurrentViewmodel = this.ViewCollection.GetViewmodel(this.ViewCollection.CancelPage);

            this.CurrentViewmodel.OnNavigatedTo();

            this.InstallStageChange(InstallerStage.Error);
        }

        private void StartSequence(Sequence sequence)
        {
            this.ButtonStateManager.ChangeState(InstallerStage.Configuration);

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

            // Notifies that a sequence selection has been made and set
            this.SequenceStarted?.Invoke(sequence);

            this.CurrentViewmodel?.OnNavigatedFrom();

            this.CurrentViewmodel = this.ViewCollection.GetViewmodel(this.sequence[0]);

            this.CurrentViewmodel.OnNavigatedTo();
        }

        private void Navigate(IViewmodel view)
        {
            // Tell the current view that we're navigating away from it
            this.CurrentViewmodel.OnNavigatedFrom();

            this.CurrentViewmodel = view;

            // Tell the new view we've just navigated to it
            this.CurrentViewmodel.OnNavigatedTo();
        }

        public virtual void InstallStageChange(InstallerStage installerStage)
        {
            this.ButtonStateManager.ChangeState(installerStage);
        }
    }
}