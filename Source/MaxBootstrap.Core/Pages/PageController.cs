using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxBootstrap.Core.Pages
{
    public class PageController : ObservableBase, IPageController
    {
        private PageCollection pageCollection;

        private IList<IPage> sequence;

        private IPage currentPage;

        private ushort sequenceIndex;

        public IPage CurrentPage
        {
            get
            {
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
            this.CurrentPage = pageCollection.StartPage;
        }

        public void GoBack()
        {
            if (this.sequenceIndex > 0)
            {
                this.CurrentPage = this.sequence[--sequenceIndex];
            }
            else if (this.sequenceIndex == 0)
            {
                this.CurrentPage = this.pageCollection.StartPage;
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
            this.StartSequence(this.pageCollection.InstallSequence);
        }

        public void StartUpgradeSequence()
        {
            this.StartSequence(this.pageCollection.UpgradeSequence);
        }

        public void StartModifySequence()
        {
            this.StartSequence(this.pageCollection.ModifySequence);
        }

        public void StartRepairSequence()
        {
            this.StartSequence(this.pageCollection.RepairSequence);
        }

        private void StartSequence(IEnumerable<IPage> sequence)
        {
            this.sequenceIndex = 0;

            this.sequence = sequence.ToList();

            this.currentPage = this.sequence[0];
        }
    }
}
