using System.Collections.Generic;

namespace MaxBootstrap.Core.Pages
{
    public class PageCollection
    {
        private readonly IDictionary<string, IPage> pages;

        private IList<IPage> installSequence;

        private IList<IPage> upgradeSequence;

        private IList<IPage> modifySequence;

        private IList<IPage> repairSequence;

        public IPage StartPage { get; set; }

        public IPage ErrorPage { get; set; }

        public IPage CancelPage { get; set; }

        public PageCollection()
        {
            this.pages = new Dictionary<string, IPage>();
            this.installSequence = new List<IPage>();
            this.upgradeSequence = new List<IPage>();
            this.modifySequence = new List<IPage>();
            this.repairSequence = new List<IPage>();
        }

        public void RegisterPage(IPage page)
        {
            this.RegisterPage(typeof(IPage).Name, page);
        }

        public void RegisterPage(string pageID, IPage page)
        {
            if (!this.pages.ContainsKey(pageID))
            {
                this.pages[pageID] = page;
            }
        }

        public void SetInstallSequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.installSequence);
        }

        public void SetUpgradeSequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.upgradeSequence);
        }

        public void SetModifySequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.modifySequence);
        }

        public void SetRepairSequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.repairSequence);
        }

        public IEnumerable<IPage> InstallSequence
        {
            get
            {
                return this.installSequence;
            }
        }

        public IEnumerable<IPage> UpgradeSequence
        {
            get
            {
                return this.upgradeSequence;
            }
        }

        public IEnumerable<IPage> ModifySequence
        {
            get
            {
                return this.modifySequence;
            }
        }

        public IEnumerable<IPage> RepairSequence
        {
            get
            {
                return this.repairSequence;
            }
        }

        private void SetSequence(IEnumerable<string> sequence, IList<IPage> pageList)
        {
            foreach (var pageName in sequence)
            {
                if (this.pages.ContainsKey(pageName))
                {
                    pageList.Add(this.pages[pageName]);
                }
            }
        }
    }
}
