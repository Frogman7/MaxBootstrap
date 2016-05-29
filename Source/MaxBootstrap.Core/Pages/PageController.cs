using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxBootstrap.Core.Pages
{
    public class PageController : ObservableBase, IPageController
    {
        private IList<IPage> sequence;

        private IPage currentPage;

        private ushort sequenceIndex;

        public ButtonStateManager ButtonStateManager { get; protected set; }

        public IPage CurrentPage
        {
            get
            {
                if (this.currentPage == null)
                {
                    this.currentPage = this.PageCollection.StartPage;
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
            this.CurrentPage = pageCollection.StartPage;
            this.ButtonStateManager = new ButtonStateManager();
        }

        public void GoBack()
        {
            if (this.sequenceIndex > 0)
            {
                this.CurrentPage = this.sequence[--sequenceIndex];
            }
            else if (this.sequenceIndex == 0)
            {
                this.CurrentPage = this.PageCollection.StartPage;
            }

            // TODO Throw error of some kind on else condition
        }

        public void GoNext()
        {
            if (this.sequenceIndex < this.sequence.Count)
            {
                this.CurrentPage = this.sequence[++sequenceIndex];
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
            this.CurrentPage = this.PageCollection.ErrorPage;
        }

        private void StartSequence(IEnumerable<IPage> sequence)
        {
            this.sequenceIndex = 0;

            this.sequence = sequence.ToList();

            this.CurrentPage = this.sequence[0];
        }
    }
}
