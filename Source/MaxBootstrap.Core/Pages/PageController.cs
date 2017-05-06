using System.Collections.Generic;
using System.Linq;
using MaxBootstrap.UI;

namespace MaxBootstrap.Core.Pages
{
    public class PageController : ObservableBase, IPageController
    {
        private IList<string> sequence;

        private IPage currentPage;

        private ushort sequenceIndex;

        public ButtonStateManager ButtonStateManager { get; protected set; }

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

            // TODO Change hardcoded strings
            this.ButtonStateManager.NextButton.Text = "Install";
            this.ButtonStateManager.NextButton.Command = new DelegateCommand(this.StartInstallSequence);
            this.ButtonStateManager.BackButton.Command = new DelegateCommand(this.GoBack);
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

                //this.ButtonStateManager.ModifyButton.Visible = false;
                //this.ButtonStateManager.UpgradeButton.Visible = false;
                //this.ButtonStateManager.RepairButton.Visible = false;
                this.ButtonStateManager.BackButton.Visible = false;

                this.ButtonStateManager.NextButton.Command = new DelegateCommand(this.StartInstallSequence);
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
            this.StartSequence(this.PageCollection.InstallSequence);
        }

        public void StartUpgradeSequence()
        {
            this.StartSequence(this.PageCollection.UpgradeSequence);
        }

        public void StartModifySequence()
        {
            this.StartSequence(this.PageCollection.ModifySequence);
        }

        public void StartRepairSequence()
        {
            this.StartSequence(this.PageCollection.RepairSequence);
        }

        public void GoToErrorPage()
        {
            this.CurrentPage = this.PageCollection.GetPage(this.PageCollection.ErrorPage);
        }

        public void GoToCancelPage()
        {
            this.CurrentPage = this.PageCollection.GetPage(this.PageCollection.CancelPage);
        }

        private void StartSequence(IEnumerable<string> sequence)
        {
            // TODO Change hardcoded strings
            this.ButtonStateManager.NextButton.Text = "Next";
            this.ButtonStateManager.NextButton.Command = new DelegateCommand(this.GoNext);

            this.ButtonStateManager.ModifyButton.Visible = false;
            this.ButtonStateManager.UpgradeButton.Visible = false;
            this.ButtonStateManager.RepairButton.Visible = false;
            this.ButtonStateManager.BackButton.Visible = true;

            this.sequenceIndex = 0;

            this.sequence = sequence.ToList();

            this.CurrentPage = this.PageCollection.GetPage(this.sequence[0]);
        }
    }
}
