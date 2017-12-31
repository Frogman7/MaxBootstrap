using System.Collections.Generic;

namespace MaxBootstrap.Core.Pages
{
    public class PageCollection
    {
        private readonly IDictionary<string, PageActivator> pages;

        private IList<string> installSequence;

        private IList<string> upgradeSequence;

        private IList<string> modifySequence;

        private IList<string> repairSequence;

        private IList<string> uninstallSequence;

        public string StartPage { get; set; }

        public string ErrorPage { get; set; }

        public string CancelPage { get; set; }

        public PageCollection()
        {
            this.pages = new Dictionary<string, PageActivator>();
            this.installSequence = new List<string>();
            this.uninstallSequence = new List<string>();
            this.upgradeSequence = new List<string>();
            this.modifySequence = new List<string>();
            this.repairSequence = new List<string>();
        }

        public IPage GetPage(string pageID)
        {
            if (string.IsNullOrEmpty(pageID))
            {
                // TODO throw error or something
                return null;
            }

            if (this.pages.ContainsKey(pageID))
            {
                return this.pages[pageID].GetInstance();
            }

            // TODO Throw exception or at least log

            return null;
        }

        public void RegisterPage<TPageConcrete>(bool maintainInstance = false, params object[] parameters)
        {
            this.RegisterPage<TPageConcrete>(typeof(TPageConcrete).Name, maintainInstance, parameters);
        }

        public void RegisterPage<TPageConcrete>(string pageID, bool maintainInstance = false, params object[] parameters)
        {
            if (!this.pages.ContainsKey(pageID))
            {
                this.pages[pageID] = new PageActivator(typeof(TPageConcrete), maintainInstance, parameters);
            }
        }

        public void SetInstallSequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.installSequence);
        }

        public void SetUninstallSequence(IEnumerable<string> sequence)
        {
            this.SetSequence(sequence, this.uninstallSequence);
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

        public IEnumerable<string> InstallSequence
        {
            get
            {
                return this.installSequence;
            }
        }

        public IEnumerable<string> UpgradeSequence
        {
            get
            {
                return this.upgradeSequence;
            }
        }

        public IEnumerable<string> ModifySequence
        {
            get
            {
                return this.modifySequence;
            }
        }

        public IEnumerable<string> RepairSequence
        {
            get
            {
                return this.repairSequence;
            }
        }

        public IEnumerable<string> UninstallSequence
        {
            get
            {
                return this.uninstallSequence;
            }
        }

        private void SetSequence(IEnumerable<string> sequence, IList<string> pageList)
        {
            foreach (var pageName in sequence)
            {
                if (this.pages.ContainsKey(pageName))
                {
                    pageList.Add(pageName);
                }
                else
                {
                    // TODO Thow exception or something
                }
            }
        }
    }
}
