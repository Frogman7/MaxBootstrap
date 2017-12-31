using System.Collections.Generic;
using System.Linq;
using MaxBootstrap.UI;
using System;
using System.ComponentModel;
using MaxBootstrap.Core.Enums;

namespace MaxBootstrap.Core.Pages
{
    public class PageController : ObservableBase, IPageController
    {
        public event Action<Sequence> SequenceStarted;

        public ButtonStateManager ButtonStateManager { get; protected set; }

        private IList<string> sequence;

        private IPage currentPage;

        private ushort sequenceIndex;

        public IPage CurrentPage
        {
            get
            {
                if (this.currentPage == null)
                {
                    this.currentPage = this.PageCollection.GetPage(this.PageCollection.StartPage);
                }

                return this.currentPage;
            }

            protected set
            {
                this.currentPage = value;
                this.NotifyPropertyChanged();
            }
        }

        public PageCollection PageCollection { get; protected set; }

        public PageController(PageCollection pageCollection)
        {
            this.PageCollection = pageCollection;
            this.CurrentPage = this.PageCollection.GetPage(this.PageCollection.StartPage);
            this.ButtonStateManager = new ButtonStateManager();

            this.ButtonStateManager.NextButton.Command = new DelegateCommand(this.GoNext);
            this.ButtonStateManager.BackButton.Command = new DelegateCommand(this.GoBack);
            this.ButtonStateManager.InstallButton.Command = new DelegateCommand(this.StartInstallSequence);
            this.ButtonStateManager.UninstallButton.Command = new DelegateCommand(this.StartUninstallSequence);
            this.ButtonStateManager.UpgradeButton.Command = new DelegateCommand(this.StartUpgradeSequence);
            this.ButtonStateManager.ModifyButton.Command = new DelegateCommand(this.StartModifySequence);
            this.ButtonStateManager.RepairButton.Command = new DelegateCommand(this.StartRepairSequence);
            this.ButtonStateManager.CancelButton.Command = new DelegateCommand(this.GoToCancelPage);
        }

        public void GoBack()
        {
            if (this.sequenceIndex > 0)
            {
                this.CurrentPage = this.PageCollection.GetPage(this.sequence[--this.sequenceIndex]);
            }
            else if (this.sequenceIndex == 0)
            {
                // TODO Consider maybe exiting instead of going all the way back to start
                this.CurrentPage = this.PageCollection.GetPage(this.PageCollection.StartPage);

                this.ButtonStateManager.BackButton.Visible = false;
            }

            // TODO Throw error of some kind on else condition
        }

        public void GoNext()
        {
            if (this.sequenceIndex < this.sequence.Count)
            {
                this.CurrentPage = this.PageCollection.GetPage(this.sequence[++this.sequenceIndex]);
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

        public void GoToErrorPage()
        {
            this.CurrentPage = this.PageCollection.GetPage(this.PageCollection.ErrorPage);
        }

        public void GoToCancelPage()
        {
            this.CurrentPage = this.PageCollection.GetPage(this.PageCollection.CancelPage);
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
                        this.sequence = this.PageCollection.InstallSequence.ToList();
                        break;
                    }
                case Sequence.Modify:
                    {
                        this.sequence = this.PageCollection.ModifySequence.ToList();
                        break;
                    }
                case Sequence.Upgrade:
                    {
                        this.sequence = this.PageCollection.UpgradeSequence.ToList();
                        break;
                    }
                case Sequence.Repair:
                    {
                        this.sequence = this.PageCollection.RepairSequence.ToList();
                        break;
                    }
                case Sequence.Uninstall:
                    {
                        this.sequence = this.PageCollection.UninstallSequence.ToList();
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

            this.CurrentPage = this.PageCollection.GetPage(this.sequence[0]);
        }
    }
}
